using Csla.Rules;

namespace BusinessLibrary
{
  public class NoZAllowed : BusinessRule
  {
    public NoZAllowed(Csla.Core.IPropertyInfo primaryProperty)
      : base(primaryProperty)
    { }

    protected override void Execute(IRuleContext context)
    {
      var text = (string)ReadProperty(context.Target, PrimaryProperty);
      if (text.ToLower().Contains("z"))
        context.AddErrorResult("No letter Z allowed");
    }
  }

  public class NoZAllowedAttribute : System.ComponentModel.DataAnnotations.ValidationAttribute
  {

    public override bool IsValid(object? value)
    {
      var text = (string?)value;
      return !text.ToLower().Contains("z");
    }

    public override string FormatErrorMessage(string name) => "No letter Z allowed";
  }
}
