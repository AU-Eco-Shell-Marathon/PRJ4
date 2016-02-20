﻿using System;
using System.Linq;
using NUnit.Framework;

namespace RollingRoad.Test.Unit
{
    [TestFixture]
    public class DataListTests
    {
        [Test]
        public void AddData_DataEntryNameDoesNotMatch_ExceptionThrown()
        {
            DataList datalist = new DataList("TestName", "TestUnit");

            Assert.Throws<ArgumentException>(() => datalist.AddData(new DataEntry("InvalidName", "TestUnit", 0)));
        }

        [Test]
        public void AddData_DataEntryUnitDoesNotMatch_ExceptionThrown()
        {
            DataList datalist = new DataList("TestName", "TestUnit");

            Assert.Throws<ArgumentException>(() => datalist.AddData(new DataEntry("TestName", "InvalidUnit", 0)));
        }

        [Test]
        public void AddData_DataEntry_DataAdded()
        {
            DataList datalist = new DataList("TestName", "TestUnit");

            datalist.AddData(new DataEntry("TestName", "TestUnit", 123));

            Assert.That(datalist.GetData().First(), Is.EqualTo(123));
        }

        [Test]
        public void AddData_DoubleAsData_DataAdded()
        {
            DataList datalist = new DataList("TestName", "TestUnit");

            datalist.AddData(123);

            Assert.That(datalist.GetData().First(), Is.EqualTo(123));
        }

        [Test]
        public void Ctor_NameIsNull_ExceptionThrown()
        {
            // ReSharper disable once ObjectCreationAsStatement
            Assert.Throws<ArgumentException>(() => new DataList(null, "Test"));
        }

        [Test]
        public void Ctor_NameIsEmpty_ExceptionThrown()
        {

            // ReSharper disable once ObjectCreationAsStatement
            Assert.Throws<ArgumentException>(() => new DataList("", "Test"));
        }

        [Test]
        public void Ctor_UnitIsNull_ExceptionThrown()
        {

            // ReSharper disable once ObjectCreationAsStatement
            Assert.Throws<ArgumentException>(() => new DataList("Test", null));
        }

        [Test]
        public void Ctor_UnitsIsEmpty_ExceptionThrown()
        {

            // ReSharper disable once ObjectCreationAsStatement
            Assert.Throws<ArgumentException>(() => new DataList("Test", ""));
        }

        [Test]
        public void Ctor_NameAndUnit_NameWritten()
        {
            DataList dataList = new DataList("NameTest", "UnitTest");

            Assert.That(dataList.Name, Is.EqualTo("NameTest"));
        }


        [Test]
        public void Ctor_NameAndUnit_UnitWritten()
        {
            DataList dataList = new DataList("NameTest", "UnitTest");

            Assert.That(dataList.Unit, Is.EqualTo("UnitTest"));
        }

        [Test]
        public void GetData_NoDataAdded_NoDataPresent()
        {
            DataList list = new DataList("TestName", "TestUnit");

            Assert.That(list.GetData().Count, Is.EqualTo(0));
        }

        [Test]
        public void GetData_OneDataAdded_DataPresent()
        {
            DataList list = new DataList("TestName", "TestUnit");

            list.AddData(3);

            Assert.That(list.GetData().Count, Is.EqualTo(1));
            Assert.That(list.GetData().First(), Is.EqualTo(3));
        }

        [Test]
        public void Title_NameAndUnitSet_NameContainedInTitle()
        {
            DataList list = new DataList("TestName", "TestUnit");

            Assert.That(list.Title, Does.Contain("TestName"));
        }

        [Test]
        public void Title_NameAndUnitSet_UnitContainedInTitle()
        {
            DataList list = new DataList("TestName", "TestUnit");

            Assert.That(list.Title, Does.Contain("TestUnit"));
        }
    }
}
