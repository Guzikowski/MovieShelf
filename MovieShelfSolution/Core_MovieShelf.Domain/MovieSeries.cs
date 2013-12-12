
using System.Collections.Generic;
using System.Linq;
using Core_MovieShelf.Interface.Domain;
using Core_MovieShelf.Interface.Domain.Contracts;

namespace Core_MovieShelf.Domain
{
    public class MovieSeries : BaseEntity, IMovieSeries
    {
        public MovieSeries() { }
        public MovieSeries(IBaseEntity entity) : base(entity) { }
        public MovieSeries(IBaseEntityContract contract) : base(contract) { }

        public new TEntityContract ConvertToContract<TEntity, TEntityContract>(TEntity baseEntity, TEntityContract baseContract)
            where TEntity : MovieSeries, IMovieSeries
            where TEntityContract : MovieSeriesContract, new()
        {
            return baseEntity == null ? baseContract : base.ConvertToContract(baseEntity, baseContract);
        }
        public DomainListContract<TEntityContract> ConvertToContract<TEntity, TEntityList, TEntityContract>(IDomainList<TEntity, TEntityList> domainList)
            where TEntity : MovieSeries, IMovieSeries, new()
            where TEntityList : IEnumerable<TEntity>
            where TEntityContract : MovieSeriesContract, new()
        {
            var returnValue = new DomainListContract<TEntityContract>();
            if (domainList == null)
            {
                return returnValue;
            }
            returnValue.DomainStatus = Domain.DomainStatus.ConvertToContract(domainList.DomainStatus);
            returnValue.IsValid = domainList.IsValid;
            returnValue.EntityList = domainList.EntityList.Select(item => new TEntity().ConvertToContract(item, new TEntityContract())).ToList();
            return returnValue;
        }
        public IDomainList<TEntity, TEntityList> ConvertToDomain<TEntity, TEntityList, TEntityContract>(DomainListContract<TEntityContract> contractList)
            where TEntity : MovieSeries, IMovieSeries, new()
            where TEntityList : class, IEnumerable<TEntity>
            where TEntityContract : MovieSeriesContract, new()
        {
            var returnValue = new DomainList<TEntity, TEntityList>();
            if (contractList == null)
            {
                return returnValue;
            }
            var itemList = contractList.EntityList.Select(item => new MovieSeries(item)).Select(item2 => item2 as TEntity).ToList();
            returnValue.EntityList = itemList as TEntityList;
            return returnValue;
        }
    }
}
