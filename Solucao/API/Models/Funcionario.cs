using System;

namespace API.Models;

public class Funcionario
{
    public int FuncionarioId { get; set; }
    public string? Nome { get; set; }
    public string? cpf { get; set; }
    public DateTime CriadoEm { get; set; } = DateTime.Now;
}
