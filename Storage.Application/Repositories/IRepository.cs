﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage.Application.Repositories;

public interface IRepository
{
    Task SaveChangesAsync(CancellationToken cancellationToken);
}
