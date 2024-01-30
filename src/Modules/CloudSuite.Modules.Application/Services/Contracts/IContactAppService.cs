﻿using CloudSuite.Modules.Application.ViewModels;
using CloudSuite.Modules.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Application.Services.Contracts
{
    public interface IContactAppService
    {
        Task<ContactViewModel> GetByEmail(string email);

        Task<ContactViewModel> GetByNumber(string number);


        //Task Save(CreateContactCommand commandCreate);
    }
}
