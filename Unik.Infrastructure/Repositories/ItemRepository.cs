using Microsoft.EntityFrameworkCore;
using SqlServerContext;
using Unik.Application.Queries.Item.QueryResultDto;
using Unik.Application.Repositories;
using Unik.Domain.ValueObjects;

namespace Unik.Infrastructure.Repositories
{
    /// <summary>
    /// Item Repository
    /// </summary>
    public class ItemRepository :IItemRepository
    {
        private readonly BackendDbContext _context;
        public ItemRepository(BackendDbContext backendDbContext)
        {
            _context = backendDbContext;
        }

        void IItemRepository.AddItem(Item item)
        {
           _context.Add(item);
            _context.SaveChanges();
        }

        void IItemRepository.DeleteItem(Item item)
        {
            _context.Remove(item);
            _context.SaveChanges();
        }

        IEnumerable<ItemQueryResultDto> IItemRepository.GetAllItems()
        {
            foreach(var item in _context.Items.AsNoTracking())
            {
                yield return new ItemQueryResultDto
                {
                    Id = item.Id,
                    Description = item.Description,
                    Damage = item.Damage
                };
            }
        }

        ItemQueryResultDto IItemRepository.GetById(int id)
        {
           var model = _context.Items.AsNoTracking().FirstOrDefault(x => x.Id == id);
            if(model == null)
            {
                throw new Exception("Item not found");
            }
            return new ItemQueryResultDto
            {
                Id = model.Id,
                Description = model.Description,
                Damage = model.Damage
            };
        }

        Item IItemRepository.Load(int id)
        {
           var model = _context.Items.FirstOrDefault(x => x.Id == id);
            if(model == null)
            {
                throw new Exception("Item not found");
            }
            return model;
        }

        void IItemRepository.UpdateItem(Item item)
        {
            _context.Update(item);
            _context.SaveChanges();
        }
    }
}
