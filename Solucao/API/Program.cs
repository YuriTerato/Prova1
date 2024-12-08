using Microsoft.AspNetCore.Mvc;
using API.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDataContext>();
var app = builder.Build();

//
app.MapGet("/", () => "Hello World!");

//CADASTRAR FUNCIONARIOS//
app.MapPost("/api/funcionarios/cadastrar", ([FromBody] Funcionario funcionario, [FromServices] AppDataContext ctx) =>
{
    ctx.Funcionarios.Add(funcionario);
    ctx.SaveChanges();
    return Results.Created("", funcionario);
});

//LISTAR FUNCIONARIOS//
app.MapGet("/api/funcionarios/listar", ([FromServices] AppDataContext ctx) =>
{
    if(ctx.Funcionarios.Any())
    {
        return Results.Ok(ctx.Funcionarios.ToList());
    }
     return Results.NotFound();
});

//ALTERAR FUNCIONARIOS//
app.MapPut("/api/funcionarios/alterar/{id}", ([FromRoute] int id, [FromBody] Funcionario funcionarioAlterado, [FromServices] AppDataContext ctx) =>
{
    Funcionario? funcionario = ctx.Funcionarios.Find(id);
    if(funcionario is null)
    {
            return Results.NotFound();
    }
    funcionario.Nome = funcionarioAlterado.Nome;
    funcionario.cpf = funcionarioAlterado.cpf;

    ctx.Funcionarios.Update(funcionario);
    ctx.SaveChanges();
    return Results.Ok(funcionario);

});

//DELETAR FUNCIONARIOS
app.MapDelete("/api/funcionarios/deletar/{id}", ([FromRoute] int id, [FromServices] AppDataContext ctx) =>
{
    Funcionario? funcionario = ctx.Funcionarios.Find(id);
    if(funcionario is null)
    {
            return Results.NotFound();
    }

    ctx.Funcionarios.Remove(funcionario);
    ctx.SaveChanges();
    return Results.Ok(funcionario);
});
