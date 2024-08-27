using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToToAirline.DTOs.Passenger;
using ToToAirline.Entities;
using ToToAirline.IRepository;
using ToToAirline.IService;

namespace ToToAirline.Service
{
    public class PassengerService : IPassengerService
    {
        private readonly IRepository<Passenger> _passengerRepository;

        public PassengerService(IRepository<Passenger> passengerRepository)
        {
            _passengerRepository = passengerRepository;
        }

        public void CreatePassenger(CreatePassengetDto create)
        {
            _passengerRepository.Insert(new Passenger(create.FirstName,create.LastName,create.DateOfBirthday,create.PassportNumber));
            _passengerRepository.Commit();
        }

        public void DeletePassenger(Guid passengerId)
        {
            var passenger = _passengerRepository.Table.Where(p => p.Id == passengerId).FirstOrDefault()?? throw new Exception("Not Found Id");
            _passengerRepository.Delete(passenger);
            _passengerRepository.Commit();
        }

        public List<GetPassengerDto> GetPassengers()
        {
            var passenger = _passengerRepository.Table.Select(p => new GetPassengerDto(p.Id, p.FirstName, p.LastName, p.DateOfBirthday, p.PassportNumber)).ToList();
            return passenger;
        }

        public void UpdatePassenger(Guid passengerId, UpdatePassengerDto update)
        {
            var passenger = _passengerRepository.Table.Where(p => p.Id == passengerId).FirstOrDefault()
            ?? throw new Exception("Not Found Id");
            passenger.FirstName = update.FirstName;
            passenger.LastName = update.LastName;
            passenger.DateOfBirthday = update.DateOfBirthday;
            passenger.PassportNumber = update.PassportNumber!;

            _passengerRepository.Update(passenger);
            _passengerRepository.Commit();

            

        }
    }
}