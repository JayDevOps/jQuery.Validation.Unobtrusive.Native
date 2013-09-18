﻿using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace jQuery.Validation.Unobtrusive.Native.MVC.UnitTests
{
    [TestClass]
    public class TextBoxExtensionsRequiredTests
    {
        private class RequiredStringModel
        {
            [Required]
            public string String { get; set; }
        }

        [TestMethod]
        public void TextBoxFor_creates_required_data_attributes_for_string_with_Required_attribute()
        {
            // Arrange
            var htmlHelper = HtmlHelperFactory.Create(new RequiredStringModel());

            // Act
            var result = TextBoxExtensions.TextBoxFor(htmlHelper, exampleModel => exampleModel.String, true);

            // Assert
            Assert.AreEqual("<input " +
                            "data-msg-required=\"The String field is required.\" " +
                            "data-rule-required=\"true\" " +
                            "id=\"String\" name=\"String\" type=\"text\" value=\"\" />", result.ToHtmlString());
        }

        private class DateTimeModel
        {
            public DateTime Date { get; set; }
        }

        [TestMethod]
        public void TextBoxFor_creates_required_and_date_data_attributes_for_DateTime()
        {
            // Arrange
            var htmlHelper = HtmlHelperFactory.Create(new DateTimeModel());

            // Act
            var result = TextBoxExtensions.TextBoxFor(htmlHelper, exampleModel => exampleModel.Date, true);

            // Assert
            Assert.AreEqual("<input " +
                            "data-msg-date=\"The field Date must be a date.\" " +
                            "data-msg-required=\"The Date field is required.\" " +
                            "data-rule-date=\"true\" " +
                            "data-rule-required=\"true\" " +
                            "id=\"Date\" name=\"Date\" type=\"text\" value=\"\" />", result.ToHtmlString());
        }

        private class NullableDateTimeModel
        {
            public DateTime? Date { get; set; }
        }

        [TestMethod]
        public void TextBoxFor_creates_date_data_attributes_for_nullable_DateTime()
        {
            // Arrange
            var htmlHelper = HtmlHelperFactory.Create(new NullableDateTimeModel());

            // Act
            var result = TextBoxExtensions.TextBoxFor(htmlHelper, exampleModel => exampleModel.Date, true);

            // Assert
            Assert.AreEqual("<input " +
                            "data-msg-date=\"The field Date must be a date.\" " +
                            "data-rule-date=\"true\" " +
                            "id=\"Date\" name=\"Date\" type=\"text\" value=\"\" />", result.ToHtmlString());
        }
    }
}
