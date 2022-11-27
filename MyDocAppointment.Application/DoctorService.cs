﻿using MyDocAppointment.Business.Helpers;
using MyDocAppointment.Business.Interfaces;
using MyDocAppointment.Business.Logistics.Internal;
using MyDocAppointment.Business.Users;
using System.Numerics;

namespace MyDocAppointment.Application
{
    public class DoctorsService : IDoctorsService
    {
        private readonly IDoctorsRepository _doctorsRepository;
        public DoctorsService(IDoctorsRepository doctorsRepository)
        {
            _doctorsRepository = doctorsRepository;
        }

        public async Task Create(Doctor doctor)
        {
            await _doctorsRepository.Create(doctor);
        }

        public async Task<Result> Delete(Guid id)
        {
            Doctor doctor = await _doctorsRepository.GetById(id);
            if(doctor == null)
            {
                return Result.Failure($"Doctor with id {id} not found.");
            }
            await _doctorsRepository.Delete(doctor);
            return Result.Success();
        }

        public async Task<Result<IEnumerable<Doctor>>> GetAll()
        {
            var doctors = await _doctorsRepository.GetAll();
            if (!doctors.Any())
            {
                return Result<IEnumerable<Doctor>>.Failure($"Doctor not found.");
            }
            return Result<IEnumerable<Doctor>>.Success(doctors);
        }

        public async Task<Result<Doctor>> GetById(Guid id)
        {
            var doctor = await _doctorsRepository.GetById(id);
            if(doctor == null)
            {
                return Result<Doctor>.Failure($"Doctor with ID: {id} does not exist.");
            }
            return Result<Doctor>.Success(doctor);
        }

        public async Task SaveChanges()
        {
            await _doctorsRepository.SaveChanges();
        }
    }
}
