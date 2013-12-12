using System;
using System.Collections.Generic;
using System.Configuration;
using Core_MovieShelf.Data;
using Core_MovieShelf.Domain;
using Core_MovieShelf.Interface.Domain.Contracts;
using Core_MovieShelf.Process;
using Core_MovieShelf.Service;
using MovieDetail = Core_MovieShelf.Domain.MovieDetail;

namespace Wcf_MovieShelf
{
    public class MovieService : BaseService, IMovieService
    {
        public string HelloService(string greeting)
        {
            return string.Format("The MovieService says HI!, and thanks for the following: {0}", greeting);
        }

        public MovieDetailContract CreateMovieDetail(MovieDetailContract contract)
        {
            try
            {
                using (var context = new MovieShelfEntities(ConfigurationManager.ConnectionStrings["TestConnection"].ConnectionString))
                {
                    var provider = new MovieDetailDal(context);
                    var process = new MovieDetailProcess(provider);
                    var service = new MovieDetailService(process);

                    var result = service.Create(new MovieDetail(contract));
                    return new MovieDetail().ConvertToContract(result, new MovieDetailContract());
                }

            }
            catch (Exception exception)
            {
                return HandleExceptionResponse<MovieDetail, MovieDetailContract>(exception);
            }
        }

        public MovieSeriesContract CreateMovieSeries(MovieSeriesContract contract)
        {
            try
            {
                using (var context = new MovieShelfEntities(ConfigurationManager.ConnectionStrings["TestConnection"].ConnectionString))
                {
                    var provider = new MovieSeriesDal(context);
                    var process = new MovieSeriesProcess(provider);
                    var service = new MovieSeriesService(process);

                    var result = service.Create(new MovieSeries(contract));
                    return new MovieSeries().ConvertToContract(result, new MovieSeriesContract());
                }

            }
            catch (Exception exception)
            {
                return HandleExceptionResponse<MovieSeries, MovieSeriesContract>(exception);
            }
        }

        public MovieDetailContract FetchMovieDetail(int id, bool includeDeletion)
        {
            try
            {
                using (var context = new MovieShelfEntities(ConfigurationManager.ConnectionStrings["TestConnection"].ConnectionString))
                {
                    var provider = new MovieDetailDal(context);
                    var process = new MovieDetailProcess(provider);
                    var service = new MovieDetailService(process);

                    var result = service.Get(id, includeDeletion);
                    return new MovieDetail().ConvertToContract(result, new MovieDetailContract());
                }

            }
            catch (Exception exception)
            {
                return HandleExceptionResponse<MovieDetail, MovieDetailContract>(exception);
            }
        }

        public MovieSeriesContract FetchMovieSeries(int id, bool includeDeletion)
        {
            try
            {
                using (var context = new MovieShelfEntities(ConfigurationManager.ConnectionStrings["TestConnection"].ConnectionString))
                {
                    var provider = new MovieSeriesDal(context);
                    var process = new MovieSeriesProcess(provider);
                    var service = new MovieSeriesService(process);

                    var result = service.Get(id, includeDeletion);
                    return new MovieSeries().ConvertToContract(result, new MovieSeriesContract());
                }

            }
            catch (Exception exception)
            {
                return HandleExceptionResponse<MovieSeries, MovieSeriesContract>(exception);
            }
        }

        public DomainListContract<MovieDetailContract> FetchAllMovieDetails(bool includeDeletion)
        {
            try
            {
                using (var context = new MovieShelfEntities(ConfigurationManager.ConnectionStrings["TestConnection"].ConnectionString))
                {
                    var provider = new MovieDetailDal(context);
                    var process = new MovieDetailProcess(provider);
                    var service = new MovieDetailService(process);

                    var result = service.GetAll(includeDeletion);
                    var returnResult = new MovieDetail().ConvertToContract<MovieDetail, IEnumerable<MovieDetail>, MovieDetailContract>(result);
                    return returnResult;
                }

            }
            catch (Exception exception)
            {
                return HandleExceptionResponse<MovieDetailContract>(exception);
            }
        }

        public DomainListContract<MovieSeriesContract> FetchAllMovieSeries(bool includeDeletion)
        {
            try
            {
                using (var context = new MovieShelfEntities(ConfigurationManager.ConnectionStrings["TestConnection"].ConnectionString))
                {
                    var provider = new MovieSeriesDal(context);
                    var process = new MovieSeriesProcess(provider);
                    var service = new MovieSeriesService(process);

                    var result = service.GetAll(includeDeletion);
                    var returnResult = new MovieSeries().ConvertToContract<MovieSeries, IEnumerable<MovieSeries>, MovieSeriesContract>(result);
                    return returnResult;
                }

            }
            catch (Exception exception)
            {
                return HandleExceptionResponse<MovieSeriesContract>(exception);
            }
        }

        public MovieDetailContract SaveMovieDetail(MovieDetailContract contract)
        {
            try
            {
                using (var context = new MovieShelfEntities(ConfigurationManager.ConnectionStrings["TestConnection"].ConnectionString))
                {
                    var provider = new MovieDetailDal(context);
                    var process = new MovieDetailProcess(provider);
                    var service = new MovieDetailService(process);

                    var result = service.Save(new MovieDetail(contract));
                    return new MovieDetail().ConvertToContract(result, new MovieDetailContract());
                }

            }
            catch (Exception exception)
            {
                return HandleExceptionResponse<MovieDetail, MovieDetailContract>(exception);
            }
        }

        public MovieSeriesContract SaveMovieSeries(MovieSeriesContract contract)
        {
            try
            {
                using (var context = new MovieShelfEntities(ConfigurationManager.ConnectionStrings["TestConnection"].ConnectionString))
                {
                    var provider = new MovieSeriesDal(context);
                    var process = new MovieSeriesProcess(provider);
                    var service = new MovieSeriesService(process);

                    var result = service.Save(new MovieSeries(contract));
                    return new MovieSeries().ConvertToContract(result, new MovieSeriesContract());
                }

            }
            catch (Exception exception)
            {
                return HandleExceptionResponse<MovieSeries, MovieSeriesContract>(exception);
            }
        }

        public DomainListContract<MovieDetailContract> SaveAllMovieDetails(DomainListContract<MovieDetailContract> contract)
        {
            try
            {
                using (var context = new MovieShelfEntities(ConfigurationManager.ConnectionStrings["TestConnection"].ConnectionString))
                {
                    var provider = new MovieDetailDal(context);
                    var process = new MovieDetailProcess(provider);
                    var service = new MovieDetailService(process);

                    var domainList = new MovieDetail().ConvertToDomain<MovieDetail, IEnumerable<MovieDetail>, MovieDetailContract>(contract);
                    var result = service.SaveAll(domainList);
                    var returnResult = new MovieDetail().ConvertToContract<MovieDetail, IEnumerable<MovieDetail>, MovieDetailContract>(result);
                    return returnResult;
                }

            }
            catch (Exception exception)
            {
                return HandleExceptionResponse<MovieDetailContract>(exception);
            }
        }

        public DomainListContract<MovieSeriesContract> SaveAllMovieSeries(DomainListContract<MovieSeriesContract> contract)
        {
            try
            {
                using (var context = new MovieShelfEntities(ConfigurationManager.ConnectionStrings["TestConnection"].ConnectionString))
                {
                    var provider = new MovieSeriesDal(context);
                    var process = new MovieSeriesProcess(provider);
                    var service = new MovieSeriesService(process);

                    var domainList = new MovieSeries().ConvertToDomain<MovieSeries, IEnumerable<MovieSeries>, MovieSeriesContract>(contract);
                    var result = service.SaveAll(domainList);
                    var returnResult = new MovieSeries().ConvertToContract<MovieSeries, IEnumerable<MovieSeries>, MovieSeriesContract>(result);
                    return returnResult;
                }

            }
            catch (Exception exception)
            {
                return HandleExceptionResponse<MovieSeriesContract>(exception);
            }
        }

        public DomainStatusContract RemoveMovieDetail(int id)
        {
            try
            {
                using (var context = new MovieShelfEntities(ConfigurationManager.ConnectionStrings["TestConnection"].ConnectionString))
                {
                    var provider = new MovieDetailDal(context);
                    var process = new MovieDetailProcess(provider);
                    var service = new MovieDetailService(process);

                    var result = service.Remove(id);
                    return DomainStatus.ConvertToContract(result);
                }

            }
            catch (Exception exception)
            {
                return HandleExceptionResponse(exception);
            }
        }

        public DomainStatusContract RemoveMovieSeries(int id)
        {
            try
            {
                using (var context = new MovieShelfEntities(ConfigurationManager.ConnectionStrings["TestConnection"].ConnectionString))
                {
                    var provider = new MovieSeriesDal(context);
                    var process = new MovieSeriesProcess(provider);
                    var service = new MovieSeriesService(process);

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
