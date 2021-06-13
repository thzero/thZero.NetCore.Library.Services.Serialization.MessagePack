/* ------------------------------------------------------------------------- *
thZero.MetalTitans.Library.Services.Serialization.MessagePack
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

using MessagePack;

namespace thZero.Services.Serializer
{
    public sealed class MessagePackSerializerService : SerializerService<MessagePackSerializerService>, ISerializerService
    {
        public MessagePackSerializerService(ILogger<MessagePackSerializerService> logger) : base(logger)
        {
        }

        #region Public Methods
        public override TData DeserializeData<TData>(byte[] data)
        {
            if (data == null)
                return default;

            return MessagePackSerializer.Deserialize<TData>(data, MessagePack.Resolvers.ContractlessStandardResolver.Options);
        }

        public override byte[] SerializeData<TData>(TData data)
        {
            if (data == null)
                return null;

            //output = JsonSerializer.Serialize(message);
            //output = Convert.ToBase64String(MessagePackSerializer.Serialize(message, MessagePack.Resolvers.ContractlessStandardResolver.Options));
            return MessagePackSerializer.Serialize(data, MessagePack.Resolvers.ContractlessStandardResolver.Options);
        }
        #endregion
    }
}
