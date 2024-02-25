using CamposDealerWebProject.Models;

namespace CamposDealerWebProject.Repositories.Interfaces;

public interface IUnityOfWork
{
    IRepository<Cliente> ClientRepository { get; }
    IRepository<Produto> ProdutoRepository { get; }
    IRepository<Venda> VendaRepository { get; }
    Task Commit();
}
