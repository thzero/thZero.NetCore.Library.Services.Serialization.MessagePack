/* ------------------------------------------------------------------------- *
thZero.MetalTitans.Library.Services
Copyright (C) 2016-2021 thZero.com

<development [at] thzero [dot] com>

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

	http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
 * ------------------------------------------------------------------------- */

using System;

using Microsoft.Extensions.Logging;

using thZero.Services;

namespace thZero.Services.Serializer
{
    public abstract class SerializerService<TService> : ServiceBase<TService>, ISerializerService
    {
        public SerializerService(ILogger<TService> logger) : base(logger)
        {
        }

        #region Public Methods
        public abstract TData DeserializeData<TData>(byte[] data);

        public virtual TData DeserializeData<TData>(string data)
        {
            return DeserializeData<TData>(Convert.FromBase64String(data));
        }

        public abstract byte[] SerializeData<TData>(TData data);

        public virtual string SerializeDataToString<TData>(TData data)
        {
            return Convert.ToBase64String(SerializeData(data));
        }
        #endregion
    }
}
