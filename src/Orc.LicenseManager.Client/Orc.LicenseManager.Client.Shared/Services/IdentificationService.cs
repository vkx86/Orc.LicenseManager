﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IdentificationService.cs" company="Wild Gums">
//   Copyright (c) 2008 - 2015 Wild Gums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.LicenseManager.Services
{
    using SystemInfo;
    using Catel;
    using Catel.Logging;

    public class IdentificationService : IIdentificationService
    {
        private static readonly ILog Log = LogManager.GetCurrentClassLogger();

        private readonly ISystemIdentificationService _systemIdentificationService;
        private readonly object _lock = new object();
        private string _machineId = string.Empty;

        public IdentificationService(ISystemIdentificationService systemIdentificationService)
        {
            Argument.IsNotNull(() => systemIdentificationService);

            _systemIdentificationService = systemIdentificationService;
        }

        public virtual string GetMachineId()
        {
            lock (_lock)
            {
                if (string.IsNullOrWhiteSpace(_machineId))
                {
                    _machineId = _systemIdentificationService.GetMachineId(LicenseElements.IdentificationSeparator, false);
                }

                return _machineId;
            }
        }
    }
}