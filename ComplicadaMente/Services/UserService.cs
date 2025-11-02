using ComplicadaMente.Components.Data;
using ComplicadaMente.Components.Models;
using Microsoft.EntityFrameworkCore;

namespace ComplicadaMente.Services
{
    public class UserService
    {
        private readonly AppDbContext _context;

        // Constructor that accepts the DbContext
        public UserService(AppDbContext context)
        {
            _context = context;
        }

        #region CRUD Operations

        // CREATE: Add a new Cliente
        public async Task<Cliente> CreateClienteAsync(Cliente cliente)
        {
            if (cliente == null)
            {
                throw new ArgumentNullException(nameof(cliente));
            }

            _context.Cliente.Add(cliente); // Add the new Cliente to the DbSet
            await _context.SaveChangesAsync(); // Save the changes to the database
            return cliente;
        }

        // READ: Get all Clientes
        public async Task<List<Cliente>> GetAllClientesAsync()
        {
            return await _context.Cliente.ToListAsync(); // Retrieve all Cliente records
        }

        // READ: Get a Cliente by its ID
        public async Task<Cliente> GetClienteByIdAsync(int clienteId)
        {
            return await _context.Cliente
                                 .FirstOrDefaultAsync(c => c.ID_Cliente == clienteId); // Find by primary key
        }

        public async Task<Cliente> Login(string email , string password)
        {
            var user = await _context.Cliente.FirstOrDefaultAsync(s => s.Email == email && s.Passe == password);
            return user ?? null;

        }
        #endregion
    }

}
