using System.ServiceModel;
using Core_MovieShelf.Interface.Domain.Contracts;

namespace Wcf_MovieShelf
{
    [ServiceContract]
    public interface IMovieService
    {
        [OperationContract]
        string HelloService(string greeting);

        [OperationContract]
        MovieDetailContract CreateMovieDetail(MovieDetailContract contract);

        [OperationContract]
        MovieSeriesContract CreateMovieSeries(MovieSeriesContract contract);

        [OperationContract]
        MovieDetailContract FetchMovieDetail(int id, bool includeDeletion);

        [OperationContract]
        MovieSeriesContract FetchMovieSeries(int id, bool includeDeletion);

        [OperationContract]
        DomainListContract<MovieDetailContract> FetchAllMovieDetails(bool includeDeletion);

        [OperationContract]
        DomainListContract<MovieSeriesContract> FetchAllMovieSeries(bool includeDeletion);

        [OperationContract]
        MovieDetailContract SaveMovieDetail(MovieDetailContract contract);

        [OperationContract]
        MovieSeriesContract SaveMovieSeries(MovieSeriesContract contract);

        [OperationContract]
        DomainListContract<MovieDetailContract> SaveAllMovieDetails(DomainListContract<MovieDetailContract> contract);

        [OperationContract]
        DomainListContract<MovieSeriesContract> SaveAllMovieSeries(DomainListContract<MovieSeriesContract> contract);

        [OperationContract]
        DomainStatusContract RemoveMovieDetail(int id);

        [OperationContract]
        DomainStatusContract RemoveMovieSeries(int id);
    }
}
