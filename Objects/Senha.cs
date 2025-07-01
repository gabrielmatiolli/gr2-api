using Microsoft.AspNetCore.Identity;

namespace gr2_api.Objects;

public class Senha
{
  public string Value { get; }

  public Senha(string value)
  {
    Value = value;
  }

  public static Result<Senha> Create(string senha)
  {
    if (string.IsNullOrWhiteSpace(senha))
      return Result<Senha>.Fail("Senha não pode ser vazia.");

    var senhaHashed = new PasswordHasher<Senha>().HashPassword(new Senha(senha), senha);

    return Result<Senha>.Ok(new Senha(senhaHashed));
  }

  public override string ToString() => Value;
}