﻿using Microsoft.Extensions.Configuration;
using SkillTracker.BusinessLayer.Interface;
using SkillTracker.BusinessLayer.Service;
using SkillTracker.Entities;
using SkillTracker.Tests.Utility;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xunit;

namespace SkillTracker.Tests.TestCases
{
    [CollectionDefinition("parallel", DisableParallelization = false)]
    public   class BoundaryTest
    {
        // private references
        static FileUtility fileUtility;
        readonly IConfigurationRoot config;
  
        private readonly InMemoryDBUtility _InMemoryDB;
        private readonly Skill _skill;
        readonly User _user;
        private IUserService _userService;
        private ISkillService _skillService;
        private IAdminService _adminService;
        String testResult;
        public BoundaryTest()
        {
            _InMemoryDB = new InMemoryDBUtility();

            _skill = new Skill
            {
                SkillName = ".Net core 3.1",
                SkillCategory = SkillCategory.DotNet,
                SkillLevel = SkillLevel.Intermediate,
                SkillType = SkillType.Programming,
                SkillTotalExperiance = 1
            };

            _user = new User
            {

                FirstName = "Dnyati",
                LastName = "Dube",
                Email = "dnyati@gmail.com",
                Mobile = 9685744263,
            };

            config = new ConfigurationBuilder().AddJsonFile("appsettings.test.json").Build();
        }
        static BoundaryTest()
        {
            fileUtility = new FileUtility();
            fileUtility.FilePath = "../../../../output_boundary_revised.txt";
            fileUtility.CreateTextFile();
        }



        // Test methods for User Service

        [Fact]
        public async Task BoundaryTestFor_ValidEmail()
        {
            try
            {
                bool isEmail = false;
                _userService = new UserService(_InMemoryDB.GetUserContext());
                if (_user.Email != "")
                {
                    Regex regex = new Regex(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,}$");
                     isEmail = regex.IsMatch(_user.Email);
                    if (isEmail == true)
                    {
                        var result = await _userService.CreateNewUser(_user);
                        testResult = "BoundaryTestFor_ValidEmail=" + "True";
                        fileUtility.WriteTestCaseResuItInText(testResult);
                        // Write test case result in xml file
                        if (config["env"] == "development")
                        {
                            cases newcase = new cases
                            {
                                TestCaseType = "Boundary",
                                Name = "BoundaryTestFor_ValidEmail",
                                expectedOutput = "True",
                                weight = 5,
                                mandatory = "True",
                                desc = "expecting to create new user after validating email Id"
                            };
                             fileUtility.WriteTestCaseResuItInXML(newcase);
                        }
                    }
                }
                else
                {
                    Assert.True(isEmail);
                }
            }
            catch (Exception exception)
            {
                testResult = "BoundaryTestFor_ValidEmail=" + "False";
                fileUtility.WriteTestCaseResuItInText(testResult);
                // Write test case result in xml file
                if (config["env"] == "development")
                {
                    cases newcase = new cases
                    {
                        TestCaseType = "Boundary",
                        Name = "BoundaryTestFor_ValidEmail",
                        expectedOutput = "False",
                        weight = 1,
                        mandatory = "False",
                        desc = "expecting to create new user after validating email Id but fail"
                    };
                    fileUtility.WriteTestCaseResuItInXML(newcase);
                }
            }
        }
        [Fact]
        public async Task BoundaryTestFor_ValidMobileNumberLength()
        {
            try
            {
                bool isMobile = false;
                _userService = new UserService(_InMemoryDB.GetUserContext());
                if (_user.Mobile != 0)
                {
                    if (_user.Mobile.ToString().Length == 10)
                    {
                        isMobile = true ;
                     }
                    if (isMobile == true)
                    {
                        var result = await _userService.CreateNewUser(_user);
                        testResult = "BoundaryTestFor_ValidMobileNumberLength=" + "True";
                        fileUtility.WriteTestCaseResuItInText(testResult);
                        // Write test case result in xml file
                        if (config["env"] == "development")
                        {
                            cases newcase = new cases
                            {
                                TestCaseType = "Boundary",
                                Name = "BoundaryTestFor_ValidMobileNumberLength",
                                expectedOutput = "True",
                                weight = 5,
                                mandatory = "True",
                                desc = "expecting to create new user after validating mobile number length as 10"
                            };
                            fileUtility.WriteTestCaseResuItInXML(newcase);
                        }
                    }
                }
                else
                {
                    Assert.True(isMobile);
                }
            }
            catch (Exception exception)
            {
                testResult = "BoundaryTestFor_ValidMobileNumberLength=" + "False";
                fileUtility.WriteTestCaseResuItInText(testResult);
                // Write test case result in xml file
                if (config["env"] == "development")
                {
                    cases newcase = new cases
                    {
                        TestCaseType = "Boundary",
                        Name = "BoundaryTestFor_ValidMobileNumberLength",
                        expectedOutput = "False",
                        weight = 1,
                        mandatory = "False",
                        desc = "expecting to create new user after validating mobile number length as 10 but fail"
                    };
                    fileUtility.WriteTestCaseResuItInXML(newcase);
                }
            }
        }
        [Fact]
        public async Task BoundaryTestFor_ValidFirstAndLastName()
        {
            try
            {
                bool isFirstNameValid = true;
                bool isLastNameValid = true;
                _userService = new UserService(_InMemoryDB.GetUserContext());
                if (_user.FirstName != "" && _user.LastName != "")
                {
                    long f;
                    long l;
                    isFirstNameValid = long.TryParse(_user.FirstName, out f);
                    isLastNameValid = long.TryParse(_user.LastName, out l);
                    if (isFirstNameValid == false && isLastNameValid == false)
                    {
                         var result = await _userService.CreateNewUser(_user);
                        testResult = "BoundaryTestFor_ValidFirstAndLastName=" + "True";
                        fileUtility.WriteTestCaseResuItInText(testResult);
                        // Write test case result in xml file
                        if (config["env"] == "development")
                        {
                            cases newcase = new cases
                            {
                                TestCaseType = "Boundary",
                                Name = "BoundaryTestFor_ValidFirstAndLastName",
                                expectedOutput = "True",
                                weight = 5,
                                mandatory = "True",
                                desc = "expecting to create new user after validating firstname and lastname as non-numeric only"
                            };
                             fileUtility.WriteTestCaseResuItInXML(newcase);
                        }
                    }
                }
                else
                {
                    Assert.False(isFirstNameValid);
                    Assert.False(isLastNameValid);
                }
            }
            catch (Exception exception)
            {
                testResult = "BoundaryTestFor_ValidFirstAndLastName=" + "False";
                fileUtility.WriteTestCaseResuItInText(testResult);
                // Write test case result in xml file
                if (config["env"] == "development")
                {
                    cases newcase = new cases
                    {
                        TestCaseType = "Boundary",
                        Name = "BoundaryTestFor_ValidFirstAndLastName",
                        expectedOutput = "False",
                        weight = 1,
                        mandatory = "False",
                        desc = "expecting to create new user after validating firstname and lastname as non-numeric only but fail"
                    };
                    fileUtility.WriteTestCaseResuItInXML(newcase);
                }
            }
        }


        //Test Methods for Skill Service
        [Fact]
        public async Task BoundaryTestFor_ValidSkillName()
        {
            try
            {
                bool isSkillNameValid = true;
             
                _skillService = new SkillService(_InMemoryDB.GetSkillContext());
                if (_skill.SkillName != "" )
                {
                    long f;
                  isSkillNameValid = long.TryParse(_skill.SkillName, out f);
                  
                    if (isSkillNameValid == false )
                    {
                        var result = await _skillService.AddNewSkill(_skill);
                        testResult = "BoundaryTestFor_ValidSkillName=" + "True";
                        fileUtility.WriteTestCaseResuItInText(testResult);
                        // Write test case result in xml file
                        if (config["env"] == "development")
                        {
                            cases newcase = new cases
                            {
                                TestCaseType = "Boundary",
                                Name = "BoundaryTestFor_ValidSkillName",
                                expectedOutput = "True",
                                weight = 5,
                                mandatory = "True",
                                desc = "expecting to create new skill after validating skill name as non-numeric only"
                            };
                             fileUtility.WriteTestCaseResuItInXML(newcase);
                        }
                    }
                }
                else
                {
                    Assert.False(isSkillNameValid);
                    
                }
            }
            catch (Exception exception)
            {
                testResult = "BoundaryTestFor_ValidSkillName=" + "False";
                fileUtility.WriteTestCaseResuItInText(testResult);
                // Write test case result in xml file
                if (config["env"] == "development")
                {
                    cases newcase = new cases
                    {
                        TestCaseType = "Boundary",
                        Name = "BoundaryTestFor_ValidSkillName",
                        expectedOutput = "False",
                        weight = 1,
                        mandatory = "False",
                        desc = "expecting to create new skill after validating skill name as non-numeric only but fail"
                    };
                    fileUtility.WriteTestCaseResuItInXML(newcase);
                }
            }
        }


    }


}
