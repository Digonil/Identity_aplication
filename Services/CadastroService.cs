﻿using AutoMapper;
using Microsoft.AspNetCore.Identity;
using UsuariosApi.Data.Dtos;
using UsuariosApi.Models;

namespace UsuariosApi.Services;

public class CadastroService
{
    private IMapper _mapper;
    private UserManager<Usuario> _userManager;

    public CadastroService(IMapper mapper, UserManager<Usuario> userManager)
    {
        _mapper = mapper;
        _userManager = userManager;
    }

    public async Task Cadastra(CreateUsuarioDto dto) 
    {
        Usuario usuario = _mapper.Map<Usuario>(dto);

        //Por usar o .CreateAsync, o retorno seria uma Task<IdentityResult>
        //Já não é mais uma Task pois utilizamos await
        IdentityResult result = await _userManager.CreateAsync(usuario, dto.Password);

        if (!result.Succeeded) throw new ApplicationException("Falha ao cadastrar usuário!");
    }
}
