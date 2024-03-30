using CamposDealerWebProject.Context;
using CamposDealerWebProject.Models;
using CamposDealerWebProject.Repositories.Interfaces;

namespace CamposDealerWebProject.Repositories;

public class UnityOfWork : IUnityOfWork, IDisposable
{
    private readonly AppDbContext _context = null;    

    private Repository<Cliente> _clienteRepository = null;
    private Repository<Produto> _produtoRepository = null;
    private Repository<Venda> _vendaRepository = null;

    private bool disposed = false;

    public UnityOfWork()
    {
        _context = new ();
    }

    public async Task CommitAsync()
    {
        await _context.SaveChangesAsync();
    }

    public IRepository<Cliente> ClientRepository
    {
        get 
        {
            _clienteRepository ??= new Repository<Cliente>(_context);
            return _clienteRepository;
        }        
    }

    public IRepository<Produto> ProdutoRepository
    {
        get
        {
            _produtoRepository ??= new Repository<Produto>(_context);
            return _produtoRepository;
        }
    }

    public IRepository<Venda> VendaRepository
    {
        get
        { 
            _vendaRepository ??= new Repository<Venda>(_context);
            return _vendaRepository;
        }
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!disposed && disposing)
        {
            _context.Dispose();
        }

        disposed = true;
    }

    public void Dispose() 
    { 
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
}
