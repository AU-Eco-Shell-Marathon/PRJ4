﻿using System.Linq;
using NUnit.Framework;
using RollingRoad.Data;

namespace RollingRoad.Test.Unit.Data
{
    [TestFixture]
    public class DataListTests
    {
        [Test]
        public void AddData_DoubleAsData_DataAdded()
        {
            DataList datalist = new DataList(new DataType("TestName", "TestUnit"));

            datalist.Data.Add(123);

            Assert.That(datalist.Data.First(), Is.EqualTo(123));
        }

        [Test]
        public void GetData_NoDataAdded_NoDataPresent()
        {
            DataList list = new DataList(new DataType("TestName", "TestUnit"));

            Assert.That(list.Data.Count, Is.EqualTo(0));
        }

        [Test]
        public void GetData_OneDataAdded_DataPresent()
        {
            DataList list = new DataList(new DataType("TestName", "TestUnit"));

            list.Data.Add(3);

            Assert.That(list.Data.Count, Is.EqualTo(1));
            Assert.That(list.Data.First(), Is.EqualTo(3));
        }

        [Test]
        public void Title_NameAndUnitSet_NameContainedInTitle()
        {
            DataList list = new DataList(new DataType("TestName", "TestUnit"));

            Assert.That(list.ToString(), Does.Contain("TestName"));
        }

        [Test]
        public void Title_NameAndUnitSet_UnitContainedInTitle()
        {
            DataList list = new DataList(new DataType("TestName", "TestUnit"));

            Assert.That(list.ToString(), Does.Contain("TestUnit"));
        }
    }
}