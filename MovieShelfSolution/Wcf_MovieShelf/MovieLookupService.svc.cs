using System;
using System.Collections.Generic;
using System.Configuration;
using Core_MovieShelf.Data;
using Core_MovieShelf.Domain;
using Core_MovieShelf.Interface.Domain.Contracts;
using Core_MovieShelf.Process;
using Core_MovieShelf.Service;
using DisplayImage = Core_MovieShelf.Domain.DisplayImage;
using GenreType = Core_MovieShelf.Domain.GenreType;
using MovieType = Core_MovieShelf.Domain.MovieType;
using RatingType = Core_MovieShelf.Domain.RatingType;
using StatusType = Core_MovieShelf.Domain.StatusType;
using ViewRatingType = Core_MovieShelf.Domain.ViewRatingType;

namespace Wcf_MovieShelf
{
    [System.Runtime.InteropServices.GuidAttribute("C1EC6733-1BE2-4408-A43C-3D7CD636710C")]
    public class MovieLookupService : BaseService, IMovieLookupService
    {
        public string HelloService(string greeting)
        {
            return string.Format("The MovieLookupService says HI!, and thanks for the following: {0}", greeting);
        }

        public DisplayImageContract CreateDisplayImage(DisplayImageContract contract)
        {
            try
            {
                using (var context = new MovieShelfEntities(ConfigurationManager.ConnectionStrings["TestConnection"].ConnectionString))
                {
                    var provider = new DisplayImageDal(context);
                    var process = new DisplayImageProcess(provider);
                    var service = new DisplayImageService(process);
                    
                    var result = service.Create(new DisplayImage(contract));
                    return new DisplayImage().ConvertToContract(result, new DisplayImageContract());
                }

            }
            catch (Exception exception)
            {
                return HandleExceptionResponse<DisplayImage, DisplayImageContract>(exception);
            }
        }

        public GenreTypeContract CreateGenreType(GenreTypeContract contract)
        {
            try
            {
                using (var context = new MovieShelfEntities(ConfigurationManager.ConnectionStrings["TestConnection"].ConnectionString))
                {
                    var provider = new GenreTypeDal(context);
                    var process = new GenreTypeProcess(provider);
                    var service = new GenreTypeService(process);

                    var result = service.Create(new GenreType(contract));
                    var returnResult = new GenreType().ConvertToContract(result, new GenreTypeContract());
                    return returnResult;
                }

            }
            catch (Exception exception)
            {
                return HandleExceptionResponse<GenreType, GenreTypeContract>(exception);
            }
        }

        public MovieTypeContract CreateMovieType(MovieTypeContract contract)
        {
            try
            {
                using (var context = new MovieShelfEntities(ConfigurationManager.ConnectionStrings["TestConnection"].ConnectionString))
                {
                    var provider = new MovieTypeDal(context);
                    var process = new MovieTypeProcess(provider);
                    var service = new MovieTypeService(process);

                    var result = service.Create(new MovieType(contract));
                    var returnResult = new MovieType().ConvertToContract(result, new MovieTypeContract());
                    return returnResult;
                }

            }
            catch (Exception exception)
            {
                return HandleExceptionResponse<MovieType, MovieTypeContract>(exception);
            }
        }

        public RatingTypeContract CreateRatingType(RatingTypeContract contract)
        {
            try
            {
                using (var context = new MovieShelfEntities(ConfigurationManager.ConnectionStrings["TestConnection"].ConnectionString))
                {
                    var provider = new RatingTypeDal(context);
                    var process = new RatingTypeProcess(provider);
                    var service = new RatingTypeService(process);

                    var result = service.Create(new RatingType(contract));
                    var returnResult = new RatingType().ConvertToContract(result, new RatingTypeContract());
                    return returnResult;
                }

            }
            catch (Exception exception)
            {
                return HandleExceptionResponse<RatingType, RatingTypeContract>(exception);
            }
        }

        public StatusTypeContract CreateStatusType(StatusTypeContract contract)
        {
            try
            {
                using (var context = new MovieShelfEntities(ConfigurationManager.ConnectionStrings["TestConnection"].ConnectionString))
                {
                    var provider = new StatusTypeDal(context);
                    var process = new StatusTypeProcess(provider);
                    var service = new StatusTypeService(process);

                    var result = service.Create(new StatusType(contract));
                    var returnResult = new StatusType().ConvertToContract(result, new StatusTypeContract());
                    return returnResult;
                }

            }
            catch (Exception exception)
            {
                return HandleExceptionResponse<StatusType, StatusTypeContract>(exception);
            }
        }

        public ViewRatingTypeContract CreateViewRatingType(ViewRatingTypeContract contract)
        {
            try
            {
                using (var context = new MovieShelfEntities(ConfigurationManager.ConnectionStrings["TestConnection"].ConnectionString))
                {
                    var provider = new ViewRatingTypeDal(context);
                    var process = new ViewRatingTypeProcess(provider);
                    var service = new ViewRatingTypeService(process);

                    var result = service.Create(new ViewRatingType(contract));
                    var returnResult = new ViewRatingType().ConvertToContract(result, new ViewRatingTypeContract());
                    return returnResult;
                }

            }
            catch (Exception exception)
            {
                return HandleExceptionResponse<ViewRatingType, ViewRatingTypeContract>(exception);
            }
        }

        public DisplayImageContract FetchDisplayImage(int id, bool includeDeletion)
        {
            try
            {
                using (var context = new MovieShelfEntities(ConfigurationManager.ConnectionStrings["TestConnection"].ConnectionString))
                {
                    var provider = new DisplayImageDal(context);
                    var process = new DisplayImageProcess(provider);
                    var service = new DisplayImageService(process);

                    var result = service.Get(id, includeDeletion);
                    return new DisplayImage().ConvertToContract(result, new DisplayImageContract());
                }

            }
            catch (Exception exception)
            {
                return HandleExceptionResponse<DisplayImage, DisplayImageContract>(exception);
            }
        }
        
        public GenreTypeContract FetchGenreType(int id, bool includeDeletion)
        {
            try
            {
                using (var context = new MovieShelfEntities(ConfigurationManager.ConnectionStrings["TestConnection"].ConnectionString))
                {
                    var provider = new GenreTypeDal(context);
                    var process = new GenreTypeProcess(provider);
                    var service = new GenreTypeService(process);

                    var result = service.Get(id, includeDeletion);
                    var returnResult = new GenreType().ConvertToContract(result, new GenreTypeContract());
                    return returnResult;
                }
                
            }
            catch (Exception exception)
            {
                return HandleExceptionResponse<GenreType, GenreTypeContract>(exception);
            }
        }

        public MovieTypeContract FetchMovieType(int id, bool includeDeletion)
        {
            try
            {
                using (var context = new MovieShelfEntities(ConfigurationManager.ConnectionStrings["TestConnection"].ConnectionString))
                {
                    var provider = new MovieTypeDal(context);
                    var process = new MovieTypeProcess(provider);
                    var service = new MovieTypeService(process);

                    var result = service.Get(id, includeDeletion);
                    var returnResult = new MovieType().ConvertToContract(result, new MovieTypeContract());
                    return returnResult;
                }

            }
            catch (Exception exception)
            {
                return HandleExceptionResponse<MovieType, MovieTypeContract>(exception);
            }
        }

        public RatingTypeContract FetchRatingType(int id, bool includeDeletion)
        {
            try
            {
                using (var context = new MovieShelfEntities(ConfigurationManager.ConnectionStrings["TestConnection"].ConnectionString))
                {
                    var provider = new RatingTypeDal(context);
                    var process = new RatingTypeProcess(provider);
                    var service = new RatingTypeService(process);

                    var result = service.Get(id, includeDeletion);
                    var returnResult = new RatingType().ConvertToContract(result, new RatingTypeContract());
                    return returnResult;
                }

            }
            catch (Exception exception)
            {
                return HandleExceptionResponse<RatingType, RatingTypeContract>(exception);
            }
        }

        public StatusTypeContract FetchStatusType(int id, bool includeDeletion)
        {
            try
            {
                using (var context = new MovieShelfEntities(ConfigurationManager.ConnectionStrings["TestConnection"].ConnectionString))
                {
                    var provider = new StatusTypeDal(context);
                    var process = new StatusTypeProcess(provider);
                    var service = new StatusTypeService(process);

                    var result = service.Get(id, includeDeletion);
                    var returnResult = new StatusType().ConvertToContract(result, new StatusTypeContract());
                    return returnResult;
                }

            }
            catch (Exception exception)
            {
                return HandleExceptionResponse<StatusType, StatusTypeContract>(exception);
            }
        }

        public ViewRatingTypeContract FetchViewRatingType(int id, bool includeDeletion)
        {
            try
            {
                using (var context = new MovieShelfEntities(ConfigurationManager.ConnectionStrings["TestConnection"].ConnectionString))
                {
                    var provider = new ViewRatingTypeDal(context);
                    var process = new ViewRatingTypeProcess(provider);
                    var service = new ViewRatingTypeService(process);

                    var result = service.Get(id, includeDeletion);
                    var returnResult = new ViewRatingType().ConvertToContract(result, new ViewRatingTypeContract());
                    return returnResult;
                }

            }
            catch (Exception exception)
            {
                return HandleExceptionResponse<ViewRatingType, ViewRatingTypeContract>(exception);
            }

        }

        public DomainListContract<DisplayImageContract> FetchAllDisplayImages(bool includeDeletion)
        {
            try
            {
                using (var context = new MovieShelfEntities(ConfigurationManager.ConnectionStrings["TestConnection"].ConnectionString))
                {
                    var provider = new DisplayImageDal(context);
                    var process = new DisplayImageProcess(provider);
                    var service = new DisplayImageService(process);

                    var result = service.GetAll(includeDeletion);
                    var returnResult = new DisplayImage().ConvertToContract<DisplayImage, IEnumerable<DisplayImage>, DisplayImageContract>(result);
                    return returnResult;
                }

            }
            catch (Exception exception)
            {
                return HandleExceptionResponse<DisplayImageContract>(exception);
            }
        }

        public DomainListContract<GenreTypeContract> FetchAllGenreTypes(bool includeDeletion)
        {
            try
            {
                using (var context = new MovieShelfEntities(ConfigurationManager.ConnectionStrings["TestConnection"].ConnectionString))
                {
                    var provider = new GenreTypeDal(context);
                    var process = new GenreTypeProcess(provider);
                    var service = new GenreTypeService(process);

                    var result = service.GetAll(includeDeletion);
                    var returnResult = new GenreType().ConvertToContract<GenreType, IEnumerable<GenreType>,GenreTypeContract>(result);
                    return returnResult;
                }
                
            }
            catch (Exception exception)
            {
                return HandleExceptionResponse<GenreTypeContract>(exception);
            }
        }

        public DomainListContract<MovieTypeContract> FetchAllMovieTypes(bool includeDeletion)
        {
            try
            {
                using (var context = new MovieShelfEntities(ConfigurationManager.ConnectionStrings["TestConnection"].ConnectionString))
                {
                    var provider = new MovieTypeDal(context);
                    var process = new MovieTypeProcess(provider);
                    var service = new MovieTypeService(process);

                    var result = service.GetAll(includeDeletion);
                    var returnResult = new MovieType().ConvertToContract<MovieType, IEnumerable<MovieType>, MovieTypeContract>(result);
                    return returnResult;
                }

            }
            catch (Exception exception)
            {
                return HandleExceptionResponse<MovieTypeContract>(exception);
            }
        }

        public DomainListContract<RatingTypeContract> FetchAllRatingTypes(bool includeDeletion)
        {
            try
            {
                using (var context = new MovieShelfEntities(ConfigurationManager.ConnectionStrings["TestConnection"].ConnectionString))
                {
                    var provider = new RatingTypeDal(context);
                    var process = new RatingTypeProcess(provider);
                    var service = new RatingTypeService(process);

                    var result = service.GetAll(includeDeletion);
                    var returnResult = new RatingType().ConvertToContract<RatingType, IEnumerable<RatingType>, RatingTypeContract>(result);
                    return returnResult;
                }

            }
            catch (Exception exception)
            {
                return HandleExceptionResponse<RatingTypeContract>(exception);
            }
        }

        public DomainListContract<StatusTypeContract> FetchAllStatusTypes(bool includeDeletion)
        {
            try
            {
                using (var context = new MovieShelfEntities(ConfigurationManager.ConnectionStrings["TestConnection"].ConnectionString))
                {
                    var provider = new StatusTypeDal(context);
                    var process = new StatusTypeProcess(provider);
                    var service = new StatusTypeService(process);

                    var result = service.GetAll(includeDeletion);
                    var returnResult = new StatusType().ConvertToContract<StatusType, IEnumerable<StatusType>, StatusTypeContract>(result);
                    return returnResult;
                }

            }
            catch (Exception exception)
            {
                return HandleExceptionResponse<StatusTypeContract>(exception);
            }
        }

        public DomainListContract<ViewRatingTypeContract> FetchAllViewRatingTypes(bool includeDeletion)
        {
            try
            {
                using (var context = new MovieShelfEntities(ConfigurationManager.ConnectionStrings["TestConnection"].ConnectionString))
                {
                    var provider = new ViewRatingTypeDal(context);
                    var process = new ViewRatingTypeProcess(provider);
                    var service = new ViewRatingTypeService(process);

                    var result = service.GetAll(includeDeletion);
                    var returnResult = new ViewRatingType().ConvertToContract<ViewRatingType, IEnumerable<ViewRatingType>, ViewRatingTypeContract>(result);
                    return returnResult;
                }

            }
            catch (Exception exception)
            {
                return HandleExceptionResponse<ViewRatingTypeContract>(exception);
            }
        }

        
        public DisplayImageContract SaveDisplayImage(DisplayImageContract contract)
        {
            try
            {
                using (var context = new MovieShelfEntities(ConfigurationManager.ConnectionStrings["TestConnection"].ConnectionString))
                {
                    var provider = new DisplayImageDal(context);
                    var process = new DisplayImageProcess(provider);
                    var service = new DisplayImageService(process);

                    var result = service.Save(new DisplayImage(contract));
                    return new DisplayImage().ConvertToContract(result, new DisplayImageContract());
                }

            }
            catch (Exception exception)
            {
                return HandleExceptionResponse<DisplayImage, DisplayImageContract>(exception);
            }
        }

        public GenreTypeContract SaveGenreType(GenreTypeContract contract)
        {
            try
            {
                using (var context = new MovieShelfEntities(ConfigurationManager.ConnectionStrings["TestConnection"].ConnectionString))
                {
                    var provider = new GenreTypeDal(context);
                    var process = new GenreTypeProcess(provider);
                    var service = new GenreTypeService(process);

                    var result = service.Save(new GenreType(contract));
                    var returnResult = new GenreType().ConvertToContract(result, new GenreTypeContract());
                    return returnResult;
                }

            }
            catch (Exception exception)
            {
                return HandleExceptionResponse<GenreType, GenreTypeContract>(exception);
            }
        }

        public MovieTypeContract SaveMovieType(MovieTypeContract contract)
        {
            try
            {
                using (var context = new MovieShelfEntities(ConfigurationManager.ConnectionStrings["TestConnection"].ConnectionString))
                {
                    var provider = new MovieTypeDal(context);
                    var process = new MovieTypeProcess(provider);
                    var service = new MovieTypeService(process);

                    var result = service.Save(new MovieType(contract));
                    var returnResult = new MovieType().ConvertToContract(result, new MovieTypeContract());
                    return returnResult;
                }

            }
            catch (Exception exception)
            {
                return HandleExceptionResponse<MovieType, MovieTypeContract>(exception);
            }
        }

        public RatingTypeContract SaveRatingType(RatingTypeContract contract)
        {
            try
            {
                using (var context = new MovieShelfEntities(ConfigurationManager.ConnectionStrings["TestConnection"].ConnectionString))
                {
                    var provider = new RatingTypeDal(context);
                    var process = new RatingTypeProcess(provider);
                    var service = new RatingTypeService(process);

                    var result = service.Save(new RatingType(contract));
                    var returnResult = new RatingType().ConvertToContract(result, new RatingTypeContract());
                    return returnResult;
                }

            }
            catch (Exception exception)
            {
                return HandleExceptionResponse<RatingType, RatingTypeContract>(exception);
            }
        }

        public StatusTypeContract SaveStatusType(StatusTypeContract contract)
        {
            try
            {
                using (var context = new MovieShelfEntities(ConfigurationManager.ConnectionStrings["TestConnection"].ConnectionString))
                {
                    var provider = new StatusTypeDal(context);
                    var process = new StatusTypeProcess(provider);
                    var service = new StatusTypeService(process);

                    var result = service.Save(new StatusType(contract));
                    var returnResult = new StatusType().ConvertToContract(result, new StatusTypeContract());
                    return returnResult;
                }

            }
            catch (Exception exception)
            {
                return HandleExceptionResponse<StatusType, StatusTypeContract>(exception);
            }
        }

        public ViewRatingTypeContract SaveViewRatingType(ViewRatingTypeContract contract)
        {
            try
            {
                using (var context = new MovieShelfEntities(ConfigurationManager.ConnectionStrings["TestConnection"].ConnectionString))
                {
                    var provider = new ViewRatingTypeDal(context);
                    var process = new ViewRatingTypeProcess(provider);
                    var service = new ViewRatingTypeService(process);

                    var result = service.Save(new ViewRatingType(contract));
                    var returnResult = new ViewRatingType().ConvertToContract(result, new ViewRatingTypeContract());
                    return returnResult;
                }

            }
            catch (Exception exception)
            {
                return HandleExceptionResponse<ViewRatingType, ViewRatingTypeContract>(exception);
            }
        }

        public DomainListContract<DisplayImageContract> SaveAllDisplayImages(DomainListContract<DisplayImageContract> contract)
        {
            try
            {
                using (var context = new MovieShelfEntities(ConfigurationManager.ConnectionStrings["TestConnection"].ConnectionString))
                {
                    var provider = new DisplayImageDal(context);
                    var process = new DisplayImageProcess(provider);
                    var service = new DisplayImageService(process);

                    var domainList = new DisplayImage().ConvertToDomain<DisplayImage, IEnumerable<DisplayImage>, DisplayImageContract>(contract);
                    var result = service.SaveAll(domainList);
                    var returnResult = new DisplayImage().ConvertToContract<DisplayImage, IEnumerable<DisplayImage>, DisplayImageContract>(result);
                    return returnResult;
                }

            }
            catch (Exception exception)
            {
                return HandleExceptionResponse<DisplayImageContract>(exception);
            }
        }

        public DomainListContract<GenreTypeContract> SaveAllGenreTypes(DomainListContract<GenreTypeContract> contract)
        {
            try
            {
                using (var context = new MovieShelfEntities(ConfigurationManager.ConnectionStrings["TestConnection"].ConnectionString))
                {
                    var provider = new GenreTypeDal(context);
                    var process = new GenreTypeProcess(provider);
                    var service = new GenreTypeService(process);

                    var domainList = new GenreType().ConvertToDomain<GenreType, IEnumerable<GenreType>, GenreTypeContract>(contract);
                    var result = service.SaveAll(domainList);
                    var returnResult = new GenreType().ConvertToContract<GenreType, IEnumerable<GenreType>, GenreTypeContract>(result);
                    return returnResult;
                }

            }
            catch (Exception exception)
            {
                return HandleExceptionResponse<GenreTypeContract>(exception);
            }
        }

        public DomainListContract<MovieTypeContract> SaveAllMovieTypes(DomainListContract<MovieTypeContract> contract)
        {
            try
            {
                using (var context = new MovieShelfEntities(ConfigurationManager.ConnectionStrings["TestConnection"].ConnectionString))
                {
                    var provider = new MovieTypeDal(context);
                    var process = new MovieTypeProcess(provider);
                    var service = new MovieTypeService(process);

                    var domainList = new MovieType().ConvertToDomain<MovieType, IEnumerable<MovieType>, MovieTypeContract>(contract);
                    var result = service.SaveAll(domainList);
                    var returnResult = new MovieType().ConvertToContract<MovieType, IEnumerable<MovieType>, MovieTypeContract>(result);
                    return returnResult;
                }

            }
            catch (Exception exception)
            {
                return HandleExceptionResponse<MovieTypeContract>(exception);
            }
        }

        public DomainListContract<RatingTypeContract> SaveAllRatingTypes(DomainListContract<RatingTypeContract> contract)
        {
            try
            {
                using (var context = new MovieShelfEntities(ConfigurationManager.ConnectionStrings["TestConnection"].ConnectionString))
                {
                    var provider = new RatingTypeDal(context);
                    var process = new RatingTypeProcess(provider);
                    var service = new RatingTypeService(process);

                    var domainList = new RatingType().ConvertToDomain<RatingType, IEnumerable<RatingType>, RatingTypeContract>(contract);
                    var result = service.SaveAll(domainList);
                    var returnResult = new RatingType().ConvertToContract<RatingType, IEnumerable<RatingType>, RatingTypeContract>(result);
                    return returnResult;
                }

            }
            catch (Exception exception)
            {
                return HandleExceptionResponse<RatingTypeContract>(exception);
            }
        }

        public DomainListContract<StatusTypeContract> SaveAllStatusTypes(DomainListContract<StatusTypeContract> contract)
        {
            try
            {
                using (var context = new MovieShelfEntities(ConfigurationManager.ConnectionStrings["TestConnection"].ConnectionString))
                {
                    var provider = new StatusTypeDal(context);
                    var process = new StatusTypeProcess(provider);
                    var service = new StatusTypeService(process);

                    var domainList = new StatusType().ConvertToDomain<StatusType, IEnumerable<StatusType>, StatusTypeContract>(contract);
                    var result = service.SaveAll(domainList);
                    var returnResult = new StatusType().ConvertToContract<StatusType, IEnumerable<StatusType>, StatusTypeContract>(result);
                    return returnResult;
                }

            }
            catch (Exception exception)
            {
                return HandleExceptionResponse<StatusTypeContract>(exception);
            }
        }

        public DomainListContract<ViewRatingTypeContract> SaveAllViewRatingTypes(DomainListContract<ViewRatingTypeContract> contract)
        {
            try
            {
                using (var context = new MovieShelfEntities(ConfigurationManager.ConnectionStrings["TestConnection"].ConnectionString))
                {
                    var provider = new ViewRatingTypeDal(context);
                    var process = new ViewRatingTypeProcess(provider);
                    var service = new ViewRatingTypeService(process);

                    var domainList = new ViewRatingType().ConvertToDomain<ViewRatingType, IEnumerable<ViewRatingType>, ViewRatingTypeContract>(contract);
                    var result = service.SaveAll(domainList);
                    var returnResult = new ViewRatingType().ConvertToContract<ViewRatingType, IEnumerable<ViewRatingType>, ViewRatingTypeContract>(result);
                    return returnResult;
                }

            }
            catch (Exception exception)
            {
                return HandleExceptionResponse<ViewRatingTypeContract>(exception);
            }
        }

        
        public DomainStatusContract RemoveDisplayImage(int id)
        {
            try
            {
                using (var context = new MovieShelfEntities(ConfigurationManager.ConnectionStrings["TestConnection"].ConnectionString))
                {
                    var provider = new DisplayImageDal(context);
                    var process = new DisplayImageProcess(provider);
                    var service = new DisplayImageService(process);

                    var result = service.Remove(id);
                    return DomainStatus.ConvertToContract(result);
                }

            }
            catch (Exception exception)
            {
                return HandleExceptionResponse(exception);
            }
        }

        public DomainStatusContract RemoveGenreType(int id)
        {
            try
            {
                using (var context = new MovieShelfEntities(ConfigurationManager.ConnectionStrings["TestConnection"].ConnectionString))
                {
                    var provider = new GenreTypeDal(context);
                    var process = new GenreTypeProcess(provider);
                    var service = new GenreTypeService(process);

                    var result = service.Remove(id);
                    return DomainStatus.ConvertToContract(result);
                }

            }
            catch (Exception exception)
            {
                return HandleExceptionResponse(exception);
            }
        }

        public DomainStatusContract RemoveMovieType(int id)
        {
            try
            {
                using (var context = new MovieShelfEntities(ConfigurationManager.ConnectionStrings["TestConnection"].ConnectionString))
                {
                    var provider = new MovieTypeDal(context);
                    var process = new MovieTypeProcess(provider);
                    var service = new MovieTypeService(process);

                    var result = service.Remove(id);
                    return DomainStatus.ConvertToContract(result);
                }

            }
            catch (Exception exception)
            {
                return HandleExceptionResponse(exception);
            }
        }

        public DomainStatusContract RemoveRatingType(int id)
        {
            try
            {
                using (var context = new MovieShelfEntities(ConfigurationManager.ConnectionStrings["TestConnection"].ConnectionString))
                {
                    var provider = new RatingTypeDal(context);
                    var process = new RatingTypeProcess(provider);
                    var service = new RatingTypeService(process);

                    var result = service.Remove(id);
                    return DomainStatus.ConvertToContract(result);
                }

            }
            catch (Exception exception)
            {
                return HandleExceptionResponse(exception);
            }
        }

        public DomainStatusContract RemoveStatusType(int id)
        {
            try
            {
                using (var context = new MovieShelfEntities(ConfigurationManager.ConnectionStrings["TestConnection"].ConnectionString))
                {
                    var provider = new StatusTypeDal(context);
                    var process = new StatusTypeProcess(provider);
                    var service = new StatusTypeService(process);

                    var result = service.Remove(id);
                    return DomainStatus.ConvertToContract(result);
                }

            }
            catch (Exception exception)
            {
                return HandleExceptionResponse(exception);
            }
        }

        public DomainStatusContract RemoveViewRatingType(int id)
        {
            try
            {
                using (var context = new MovieShelfEntities(ConfigurationManager.ConnectionStrings["TestConnection"].ConnectionString))
                {
                    var provider = new ViewRatingTypeDal(context);
                    var process = new ViewRatingTypeProcess(provider);
                    var service = new ViewRatingTypeService(process);

                    var result = service.Remove(id);
                    return DomainStatus.ConvertToContract(result);
                }

            }
            catch (Exception exception)
            {
                return HandleExceptionResponse(exception);
            }
        }


    }
}
