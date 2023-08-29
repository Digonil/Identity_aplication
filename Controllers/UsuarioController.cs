using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UsuariosApi.Data.Dtos;
using UsuariosApi.Models;
using UsuariosApi.Services;

namespace UsuariosApi.Controllers;

[ApiController]
[Route("[Controller]")]
public class UsuarioController : ControllerBase
{
    private CadastroService _cadastroService;

    public UsuarioController(CadastroService cadastroService)
    {
        _cadastroService = cadastroService;
    }


    //O método se tornou assincrono, é necessário indicar isso com um async (O retorno será umas Task)

    [HttpPost]
    public async Task<IActionResult> CadastraUsuario(CreateUsuarioDto dto)
    {
        await _cadastroService.Cadastra(dto);
        return Ok("Usuario Cadastrado!!!");
    }
}
