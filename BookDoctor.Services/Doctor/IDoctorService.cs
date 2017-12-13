namespace BookDoctor.Services.Doctor
{
    using BookDoctor.Services.Doctor.Models;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IDoctorService
    {
        Task<IEnumerable<DoctorServiceModel>> AllAsync();        
    }
}
