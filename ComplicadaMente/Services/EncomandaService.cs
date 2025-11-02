using System.Collections.Generic;
using ComplicadaMente.Components.Data;
using ComplicadaMente.Components.Models;
using Microsoft.EntityFrameworkCore;

public class EncomendaService
{
    private readonly AppDbContext _context;

    public EncomendaService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Encomenda>> GetEncomendasAsync()
    {
        return await _context.Encomenda.ToListAsync();
    }

    public async Task<Encomenda> GetEncomendaByIdAsync(int id)
    {
        return await _context.Encomenda.FindAsync(id);
    }

    public async Task<Encomenda> AddEncomendaAsync(Encomenda encomenda)
    {
        _context.Encomenda.Add(encomenda);
        await _context.SaveChangesAsync();
        return encomenda;
    }

    public async Task UpdateEncomendaAsync(Encomenda encomenda)
    {
        _context.Encomenda.Update(encomenda);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteEncomendaAsync(int id)
    {
        var encomenda = await _context.Encomenda.FindAsync(id);
        if (encomenda != null)
        {
            _context.Encomenda.Remove(encomenda);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<List<EncomendaPuzzle>> GetEncomendaPuzzlesAsync()
    {
        return await _context.EncomendaPuzzle.ToListAsync();
    }

    public async Task<EncomendaPuzzle> GetEncomendaPuzzleByIdAsync(int encomendaId, int puzzleId)
    {
        return await _context.EncomendaPuzzle.FindAsync(encomendaId, puzzleId);
    }

    public async Task<List<Encomenda>> GetEncomendaByUserIdAsync(int UserId)
    {
        return await  _context.Encomenda.Include(s=>s.EncomendaPuzzle).Where(s=>s.ID_Cliente==UserId).ToListAsync();
    }


    public async Task AddEncomendaPuzzleAsync(EncomendaPuzzle encomendaPuzzle)
    {
        _context.EncomendaPuzzle.Add(encomendaPuzzle);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateEncomendaPuzzleAsync(EncomendaPuzzle encomendaPuzzle)
    {
        _context.EncomendaPuzzle.Update(encomendaPuzzle);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteEncomendaPuzzleAsync(int encomendaId, int puzzleId)
    {
        var encomendaPuzzle = await _context.EncomendaPuzzle.FindAsync(encomendaId, puzzleId);
        if (encomendaPuzzle != null)
        {
            _context.EncomendaPuzzle.Remove(encomendaPuzzle);
            await _context.SaveChangesAsync();
        }
    }
}
