using Dados.Config;
using Dados.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32.SafeHandles;
using System.Runtime.InteropServices;

namespace Dados.Repositorios
{
    public class RepositorioBase<T> : IRepositorio<T>, IDisposable where T : class
    {
        private readonly DbContextOptions<ContextoBase> _dbContextOptions;

        public RepositorioBase()
        {
            _dbContextOptions = new DbContextOptions<ContextoBase>();
        }

        public async Task Adicionar(T objeto)
        {
            using (var data = new ContextoBase(_dbContextOptions))
            {
                await data.Set<T>().AddAsync(objeto);

                await data.SaveChangesAsync();
            }
        }

        public async Task Atualizar(T objeto)
        {
            using (var data = new ContextoBase(_dbContextOptions))
            {
                data.Set<T>().Update(objeto);

                await data.SaveChangesAsync();
            }
        }

        public async Task Excluir(T objeto)
        {
            using (var data = new ContextoBase(_dbContextOptions))
            {
                data.Set<T>().Remove(objeto);

                await data.SaveChangesAsync();
            }
        }

        public async Task<T> BuscarPeloId(int id)
        {
            using (var data = new ContextoBase(_dbContextOptions))
            {
                return await data.Set<T>().FindAsync(id);
            }
        }

        public async Task<List<T>> ListarTudo()
        {
            using (var data = new ContextoBase(_dbContextOptions))
            {
                return await data.Set<T>().AsNoTracking().ToListAsync();
            }
        }

        bool disposed = false;
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(handle);
        }

        public virtual void Dispose(bool disposing)
        {
            if (disposed) { return; };

            if (disposing)
            {
                handle.Dispose();
            }

            disposed = true;
        }
    }
}
