using System.ServiceModel;
using Core_MovieShelf.Interface.Domain.Contracts;

namespace Wcf_MovieShelf
{
    [ServiceContract]
    public interface IMovieLookupService
    {
        [OperationContract]
        string HelloService(string greeting);    

        [OperationContract]
        DisplayImageContract CreateDisplayImage(DisplayImageContract contract);

        [OperationContract]
        GenreTypeContract CreateGenreType(GenreTypeContract contract);

        [OperationContract]
        MovieTypeContract CreateMovieType(MovieTypeContract contract);

        [OperationContract]
        RatingTypeContract CreateRatingType(RatingTypeContract contract);

        [OperationContract]
        StatusTypeContract CreateStatusType(StatusTypeContract contract);

        [OperationContract]
        ViewRatingTypeContract CreateViewRatingType(ViewRatingTypeContract contract);

        [OperationContract]
        DisplayImageContract FetchDisplayImage(int id, bool includeDeletion);

        [OperationContract]
        GenreTypeContract FetchGenreType(int id, bool includeDeletion);

        [OperationContract]
        MovieTypeContract FetchMovieType(int id, bool includeDeletion);

        [OperationContract]
        RatingTypeContract FetchRatingType(int id, bool includeDeletion);

        [OperationContract]
        StatusTypeContract FetchStatusType(int id, bool includeDeletion);

        [OperationContract]
        ViewRatingTypeContract FetchViewRatingType(int id, bool includeDeletion);

        [OperationContract]
        DomainListContract<DisplayImageContract> FetchAllDisplayImages(bool includeDeletion);

        [OperationContract]
        DomainListContract<GenreTypeContract> FetchAllGenreTypes(bool includeDeletion);

        [OperationContract]
        DomainListContract<MovieTypeContract> FetchAllMovieTypes(bool includeDeletion);

        [OperationContract]
        DomainListContract<RatingTypeContract> FetchAllRatingTypes(bool includeDeletion);

        [OperationContract]
        DomainListContract<StatusTypeContract> FetchAllStatusTypes(bool includeDeletion);

        [OperationContract]
        DomainListContract<ViewRatingTypeContract> FetchAllViewRatingTypes(bool includeDeletion);

        [OperationContract]
        DisplayImageContract SaveDisplayImage(DisplayImageContract contract);

        [OperationContract]
        GenreTypeContract SaveGenreType(GenreTypeContract contract);

        [OperationContract]
        MovieTypeContract SaveMovieType(MovieTypeContract contract);

        [OperationContract]
        RatingTypeContract SaveRatingType(RatingTypeContract contract);

        [OperationContract]
        StatusTypeContract SaveStatusType(StatusTypeContract contract);

        [OperationContract]
        ViewRatingTypeContract SaveViewRatingType(ViewRatingTypeContract contract);

        [OperationContract]
        DomainListContract<DisplayImageContract> SaveAllDisplayImages(DomainListContract<DisplayImageContract> contract);

        [OperationContract]
        DomainListContract<GenreTypeContract> SaveAllGenreTypes(DomainListContract<GenreTypeContract> contract);

        [OperationContract]
        DomainListContract<MovieTypeContract> SaveAllMovieTypes(DomainListContract<MovieTypeContract> contract);

        [OperationContract]
        DomainListContract<RatingTypeContract> SaveAllRatingTypes(DomainListContract<RatingTypeContract> contract);

        [OperationContract]
        DomainListContract<StatusTypeContract> SaveAllStatusTypes(DomainListContract<StatusTypeContract> contract);

        [OperationContract]
        DomainListContract<ViewRatingTypeContract> SaveAllViewRatingTypes(DomainListContract<ViewRatingTypeContract> contract);

        [OperationContract]
        DomainStatusContract RemoveDisplayImage(int id);

        [OperationContract]
        DomainStatusContract RemoveGenreType(int id);

        [OperationContract]
        DomainStatusContract RemoveMovieType(int id);

        [OperationContract]
        DomainStatusContract RemoveRatingType(int id);

        [OperationContract]
        DomainStatusContract RemoveStatusType(int id);

        [OperationContract]
        DomainStatusContract RemoveViewRatingType(int id);
    }
}
