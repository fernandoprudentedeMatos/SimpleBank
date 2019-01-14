using SimpleBank.API.DomainModel.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleBank.API.DomainModel
{
    public class OperationDetail: ValueObject
    {
        public string accountSourceId;
        public string accountDestinyId;
        public decimal value;

        public OperationDetail(string accountSourceId, string accountDestinyId, decimal value)
        {
            this.accountSourceId = accountSourceId;
            this.accountDestinyId = accountDestinyId;
            this.value = value;
        }

        public override bool Equals(object obj)
        {
            OperationDetail otherOperationDetail = (OperationDetail)obj;

            return otherOperationDetail.accountDestinyId.Equals(this.accountDestinyId) &&
                    otherOperationDetail.accountSourceId.Equals(this.accountSourceId) &&
                    otherOperationDetail.value.Equals(this.value);
        }
    }
}
