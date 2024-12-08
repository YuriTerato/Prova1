using System;

namespace API.Models;

public class Folha
{
    public int FolhaId { get; set; }
    public Funcionario? FuncionarioId { get; set; }
    public int Quantidade { get; set; }
    public int Mes { get; set; }
    public int Ano { get; set; }

}
