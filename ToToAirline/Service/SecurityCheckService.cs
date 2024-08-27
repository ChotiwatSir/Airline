using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToToAirline.DTOs.Passenger;
using ToToAirline.DTOs.SecurityCheck;
using ToToAirline.Entities;
using ToToAirline.IRepository;
using ToToAirline.IService;

namespace ToToAirline.Service
{
    public class SecurityCheckService : ISecurityCheckService
    {
        private readonly IRepository<SecurityCheck> _repository;

        public SecurityCheckService(IRepository<SecurityCheck> repository)
        {
            _repository = repository;
        }
        public void CreateSecurityCheck(CreateSecurityCheckDto create)
        {
            _repository.Insert(new SecurityCheck(create.CheckResult, create.Comment,create.PassengerId));
            _repository.Commit();
        }

        public GetSecurityCheckDto GetSecurityCheck(Guid passengerId)
        {
            var security = _repository.Table.Where(sc => sc.Passenger.Id == passengerId)
            .Select(sc => new GetSecurityCheckDto(sc.Id, sc.CheckResult, sc.Comment, sc.Passenger.SecurityChecks
            .Select(p => new GetPassengerDto(p.Passenger.Id, p.Passenger.FirstName, p.Passenger.LastName, p.Passenger.DateOfBirthday, p.Passenger.PassportNumber))
            .ToList())).FirstOrDefault() ?? throw new Exception();

            return security;
        }
    }
}