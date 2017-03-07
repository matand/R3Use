﻿using NPoco.FluentMappings;
using R3Use.Core.Entities;

namespace R3Use.Infrastructure
{
    public class NPocoLabMappings  : Mappings
    {
        public NPocoLabMappings(bool testMode = false)
        {
            var useAutoincrement = !testMode;

            MappAssignment(useAutoincrement);

            MappPeriod(useAutoincrement);
        }

        private void MappPeriod(bool useAutoincrement)
        {
            For<Period>().PrimaryKey(k => k.Id, useAutoincrement);

            For<Period>().TableName("periods");

            For<Period>().Columns(x =>
            {
                x.Column(c => c.Description); 
                x.Column(c => c.Start); 
                x.Column(c => c.End); 
                
            });
        }

        private void MappAssignment(bool useAutoincrement)
        {
            For<Assignment>().PrimaryKey(k => k.Id, useAutoincrement);

            For<Assignment>().TableName("assignments");

            For<Assignment>().Columns(x =>
            {
                x.Column(c => c.Name);
                x.Column(a => a.Periods).Ignore();
            });
        }
    }
}