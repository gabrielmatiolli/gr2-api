using System.Text.RegularExpressions;

namespace gr2_api.Objects;

public class Email
{
  private static readonly Regex EmailRegex = new Regex(
      @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$",
      RegexOptions.Compiled | RegexOptions.IgnoreCase);

  public string Value { get; private set; }

  public Email() { }

  public Email(string value)
  {
    Value = value;
  }

  public static Result<Email> Create(string email)
  {
    if (string.IsNullOrWhiteSpace(email))
      return Result<Email>.Fail("Email não pode ser vazio.");

    if (!EmailRegex.IsMatch(email))
      return Result<Email>.Fail("Email em formato inválido.");

    return Result<Email>.Ok(new Email(email));
  }

  public override string ToString() => Value;
}