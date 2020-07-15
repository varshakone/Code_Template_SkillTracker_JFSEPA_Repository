﻿using Microsoft.Extensions.Configuration;
using SkillTracker.BusinessLayer.Interface;
using SkillTracker.BusinessLayer.Service;
using SkillTracker.Entities;
using SkillTracker.Tests.Utility;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SkillTracker.Tests.TestCases
{
    [Collection("parallel")]
    public  class BusinessLogicTest
    {
        // private reference declaration

        readonly IConfigurationRoot config;
        static FileUtility fileUtility;
        private readonly InMemoryDBUtility _InMemoryDB;
       private readonly Skill _skill;
        readonly User _user;
        private  IUserService _userService;
        private  ISkillService _skillService;
        private IAdminService _adminService;
        String testResult;

        public BusinessLogicTest()
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
                MapSkills=2
            };

            config = new ConfigurationBuilder().AddJsonFile("appsettings.test.json").Build();
        }
        static BusinessLogicTest()
        {
            fileUtility = new FileUtility
            {
                FilePath = "../../../../output_business_revised.txt"
            };
            fileUtility.CreateTextFile();
        }

        //Test methods for Skill Service
        [Fact]
        public async Task BusinessTestFor_AddNewSkill_Possitive()
        {
            try
            {
                _skillService = new SkillService(_InMemoryDB.GetSkillContext());
                var result = await _skillService.AddNewSkill(_skill);
                if (result == "New Skill Added")
                {
                    testResult = "BusinessTestFor_AddNewSkill_Possitive=" + "True";
                    fileUtility.WriteTestCaseResuItInText(testResult);
                    // Write test case result in xml file
                    if (config["env"] == "development")
                    {
                        cases newcase = new cases
                        {
                            TestCaseType = "Business",
                            Name = "BusinessTestFor_AddNewSkill_Possitive",
                            expectedOutput = "True",
                            weight = 5,
                            mandatory = "True",
                            desc = "allows to add new skill and return success message"
                        };
                         fileUtility.WriteTestCaseResuItInXML(newcase);
                    }
                }
                else
                {
                    Assert.Equal("New Skill Added", result);
                }
            }
            catch (Exception exception)
            {
                testResult = "BusinessTestFor_AddNewSkill_Possitive=" + "False";
                fileUtility.WriteTestCaseResuItInText(testResult);
                // Write test case result in xml file
                if (config["env"] == "development")
                {
                    cases newcase = new cases
                    {
                        TestCaseType = "Business",
                        Name = "BusinessTestFor_AddNewSkill_Possitive",
                        expectedOutput = "False",
                        weight = 5,
                        mandatory = "False",
                        desc = "expected to add new skill and return success message but fail"
                    };
                     fileUtility.WriteTestCaseResuItInXML(newcase);
                }
            }
        }

        [Fact]
        public async Task BusinessTestFor_EditSkill_Possitive()
        {
            try
            {
                
                _skillService = new SkillService(_InMemoryDB.GetSkillContext());
                var result1 = await _skillService.AddNewSkill(_skill);
                _skill.SkillLevel = SkillLevel.Expert;
                _skill.SkillTotalExperiance = 10;
                var result = await _skillService.EditSkill(_skill);
                if (result == 1)
                {
                    testResult = "BusinessTestFor_EditSkill_Possitive=" + "True";
                    fileUtility.WriteTestCaseResuItInText(testResult);
                    // Write test case result in xml file
                    if (config["env"] == "development")
                    {
                        cases newcase = new cases
                        {
                            TestCaseType = "Business",
                            Name = "BusinessTestFor_EditSkill_Possitive",
                            expectedOutput = "True",
                            weight = 5,
                            mandatory = "True",
                            desc = "na"
                        };
                         fileUtility.WriteTestCaseResuItInXML(newcase);
                    }
                }
                else
                {
                    Assert.Equal(1, result);
                }
            }
            catch (Exception exception)
            {
                testResult = "BusinessTestFor_EditSkill_Possitive=" + "False";
                fileUtility.WriteTestCaseResuItInText(testResult);
                // Write test case result in xml file
                if (config["env"] == "development")
                {
                    cases newcase = new cases
                    {
                        TestCaseType = "Business",
                        Name = "BusinessTestFor_EditSkill_Possitive",
                        expectedOutput = "False",
                        weight = 5,
                        mandatory = "False",
                        desc = "na"
                    };
                     fileUtility.WriteTestCaseResuItInXML(newcase);
                }
            }
        }

        [Fact]
        public async Task BusinessTestFor_DeleteSkill_Possitive()
        {
            try
            {
               
                _skillService = new SkillService(_InMemoryDB.GetSkillContext());
                var result1 = await _skillService.AddNewSkill(_skill);
                var result = await _skillService.DeleteSkill(_skill.SkillName);
                if (result == 1)
                {
                    testResult = "BusinessTestFor_DeleteSkill_Possitive=" + "True";
                    fileUtility.WriteTestCaseResuItInText(testResult);
                    // Write test case result in xml file
                    if (config["env"] == "development")
                    {
                        cases newcase = new cases
                        {
                            TestCaseType = "Business",
                            Name = "BusinessTestFor_DeleteSkill_Possitive",
                            expectedOutput = "True",
                            weight = 5,
                            mandatory = "True",
                            desc = "na"
                        };
                         fileUtility.WriteTestCaseResuItInXML(newcase);
                    }
                }
                else
                {
                    Assert.Equal(1, result);
                }
            }
            catch (Exception exception)
            {
                testResult = "BusinessTestFor_DeleteSkill_Possitive=" + "False";
                fileUtility.WriteTestCaseResuItInText(testResult);
                // Write test case result in xml file
                if (config["env"] == "development")
                {
                    cases newcase = new cases
                    {
                        TestCaseType = "Business",
                        Name = "BusinessTestFor_DeleteSkill_Possitive",
                        expectedOutput = "False",
                        weight = 5,
                        mandatory = "False",
                        desc = "na"
                    };
                     fileUtility.WriteTestCaseResuItInXML(newcase);
                }
            }
        }

        //Test Methods for User Service

        [Fact]
        public async Task BusinessTestFor_CreateNewUser_Possitive()
        {
            try
            {
                _userService = new UserService(_InMemoryDB.GetUserContext());
                var result = await _userService.CreateNewUser(_user);
                if(result == "New User Register")
                {
                    testResult = "BusinessTestFor_CreateNewUser_Possitive=" + "True";
                    fileUtility.WriteTestCaseResuItInText(testResult);
                    // Write test case result in xml file
                    if (config["env"] == "development")
                    {
                        cases newcase = new cases
                        {
                            TestCaseType = "Business",
                            Name = "BusinessTestFor_CreateNewUser_Possitive",
                            expectedOutput = "True",
                            weight = 5,
                            mandatory = "True",
                            desc = "allows to create new user and return success message"
                        };
                         fileUtility.WriteTestCaseResuItInXML(newcase);
                    }
                }
                else
                {
                    Assert.Equal("New User Register", result);
                }
            }
            catch (Exception exception)
            {
                testResult = "BusinessTestFor_CreateNewUser_Possitive=" + "False";
                fileUtility.WriteTestCaseResuItInText(testResult);
                // Write test case result in xml file
                if (config["env"] == "development")
                {
                    cases newcase = new cases
                    {
                        TestCaseType = "Business",
                        Name = "BusinessTestFor_CreateNewUser_Possitive",
                        expectedOutput = "False",
                        weight = 5,
                        mandatory = "False",
                        desc = "allows to create new user and expecting success message but throw exception"
                    };
                     fileUtility.WriteTestCaseResuItInXML(newcase);
                }
            }
        }

        [Fact]
        public async Task BusinessTestFor_UpdateUser_Possitive()
        {
            try
            {
                
                _userService = new UserService(_InMemoryDB.GetUserContext());
                var result1 = await _userService.CreateNewUser(_user);
                _user.Email = "dubednyati@gmail.com";
                _user.MapSkills = 2;
                var result = await _userService.UpdateUser(_user);
                if (result == 1)
                {
                    testResult = "BusinessTestFor_UpdateUser_Possitive=" + "True";
                    fileUtility.WriteTestCaseResuItInText(testResult);
                    // Write test case result in xml file
                    if (config["env"] == "development")
                    {
                        cases newcase = new cases
                        {
                            TestCaseType = "Business",
                            Name = "BusinessTestFor_UpdateUser_Possitive",
                            expectedOutput = "True",
                            weight = 5,
                            mandatory = "True",
                            desc = "allows to update existing user and expecting 1 "
                        };
                         fileUtility.WriteTestCaseResuItInXML(newcase);
                    }
                }
                else
                {
                    Assert.Equal(1, result);
                }
            }
            catch (Exception exception)
            {
                testResult = "BusinessTestFor_UpdateUser_Possitive=" + "False";
                fileUtility.WriteTestCaseResuItInText(testResult);
                // Write test case result in xml file
                if (config["env"] == "development")
                {
                    cases newcase = new cases
                    {
                        TestCaseType = "Business",
                        Name = "BusinessTestFor_UpdateUser_Possitive",
                        expectedOutput = "False",
                        weight = 5,
                        mandatory = "False",
                        desc = "allows to update existing user and expecting 1 but throw exception"
                    };
                     fileUtility.WriteTestCaseResuItInXML(newcase);
                }
            }
        }

        [Fact]
        public async Task BusinessTestFor_RemoveUser_Possitive()
        {
            try
            {
                
                _userService = new UserService(_InMemoryDB.GetUserContext());
                var result1 = await _userService.CreateNewUser(_user);
                var result = await _userService.RemoveUser(_user.FirstName, _user.LastName);
                if (result == 1)
                {
                    testResult = "BusinessTestFor_RemoveUser_Possitive=" + "True";
                    fileUtility.WriteTestCaseResuItInText(testResult);
                    // Write test case result in xml file
                    if (config["env"] == "development")
                    {
                        cases newcase = new cases
                        {
                            TestCaseType = "Business",
                            Name = "BusinessTestFor_RemoveUser_Possitive",
                            expectedOutput = "True",
                            weight = 5,
                            mandatory = "True",
                            desc = "allows to delete existing user and expecting 1 "
                        };
                         fileUtility.WriteTestCaseResuItInXML(newcase);
                    }
                }
                else
                {
                    Assert.Equal(1, result);
                }
            }
            catch (Exception exception)
            {
                testResult = "BusinessTestFor_RemoveUser_Possitive=" + "False";
                fileUtility.WriteTestCaseResuItInText(testResult);
                // Write test case result in xml file
                if (config["env"] == "development")
                {
                    cases newcase = new cases
                    {
                        TestCaseType = "Business",
                        Name = "BusinessTestFor_RemoveUser_Possitive",
                        expectedOutput = "False",
                        weight = 1,
                        mandatory = "False",
                        desc = "allows to delete existing user and expecting 1 but throw exception"
                    };
                     fileUtility.WriteTestCaseResuItInXML(newcase);
                }
            }
        }

        //Test Methods for Admin Service
        [Fact]
        public async Task BusinessTestFor_AllUsers_Possitive()
        {
        try
            {
               _adminService = new AdminService(_InMemoryDB.GetUserContext());
                _userService = new UserService(_InMemoryDB.GetUserContext());
                var result1 = await _userService.CreateNewUser(_user);
                var result = await _adminService.GetAllUsers() ;
                if (result !=null)
                {
                    testResult = "BusinessTestFor_AllUsers_Possitive=" + "True";
                    fileUtility.WriteTestCaseResuItInText(testResult);
                    // Write test case result in xml file
                    if (config["env"] == "development")
                    {
                        cases newcase = new cases
                        {
                            TestCaseType = "Business",
                            Name = "BusinessTestFor_AllUsers_Possitive",
                            expectedOutput = "True",
                            weight = 5,
                            mandatory = "True",
                            desc = "Shows list of users to admin user "
                        };
                         fileUtility.WriteTestCaseResuItInXML(newcase);
                    }
                }
                else
                {
                    Assert.NotEmpty(result);
                }
            }
            catch (Exception exception)
            {
                testResult = "BusinessTestFor_AllUsers_Possitive=" + "False";
                fileUtility.WriteTestCaseResuItInText(testResult);
                // Write test case result in xml file
                if (config["env"] == "development")
                {
                    cases newcase = new cases
                    {
                        TestCaseType = "Business",
                        Name = "BusinessTestFor_AllUsers_Possitive",
                        expectedOutput = "False",
                        weight = 1,
                        mandatory = "False",
                        desc = "expecting  to shows list of users to admin user but fail"
                    };
                     fileUtility.WriteTestCaseResuItInXML(newcase);
                }
            }
        }

        [Fact]
        public async Task BusinessTestFor_SearchUserByFirstName_Possitive()
        {
            try
            {
                _adminService = new AdminService(_InMemoryDB.GetUserContext());
                _userService = new UserService(_InMemoryDB.GetUserContext());
                var result1 = await _userService.CreateNewUser(_user);
                var result = await _adminService.SearchUserByFirstName(_user.FirstName) ;
                if (result != null)
                {
                    testResult = "BusinessTestFor_SearchUserByFirstName_Possitive=" + "True";
                    fileUtility.WriteTestCaseResuItInText(testResult);
                    // Write test case result in xml file
                    if (config["env"] == "development")
                    {
                        cases newcase = new cases
                        {
                            TestCaseType = "Business",
                            Name = "BusinessTestFor_SearchUserByFirstName_Possitive",
                            expectedOutput = "True",
                            weight = 5,
                            mandatory = "True",
                            desc = "na "
                        };
                         fileUtility.WriteTestCaseResuItInXML(newcase);
                    }
                }
                else
                {
                    Assert.Contains(_user.FirstName,result.FirstName);
                }
            }
            catch (Exception exception)
            {
                testResult = "BusinessTestFor_SearchUserByFirstName_Possitive=" + "False";
                fileUtility.WriteTestCaseResuItInText(testResult);
                // Write test case result in xml file
                if (config["env"] == "development")
                {
                    cases newcase = new cases
                    {
                        TestCaseType = "Business",
                        Name = "BusinessTestFor_SearchUserByFirstName_Possitive",
                        expectedOutput = "False",
                        weight = 1,
                        mandatory = "False",
                        desc = "na"
                    };
                     fileUtility.WriteTestCaseResuItInXML(newcase);
                }
            }
        }

        [Fact]
        public async Task BusinessTestFor_SearchUserByEmail_Possitive()
        {
            try
            {
                _adminService = new AdminService(_InMemoryDB.GetUserContext());
                _userService = new UserService(_InMemoryDB.GetUserContext());
                var result1 = await _userService.CreateNewUser(_user);
                var result = await _adminService.SearchUserByEmail(_user.Email);
                if (result != null)
                {
                    testResult = "BusinessTestFor_SearchUserByEmail_Possitive=" + "True";
                    fileUtility.WriteTestCaseResuItInText(testResult);
                    // Write test case result in xml file
                    if (config["env"] == "development")
                    {
                        cases newcase = new cases
                        {
                            TestCaseType = "Business",
                            Name = "BusinessTestFor_SearchUserByEmail_Possitive",
                            expectedOutput = "True",
                            weight = 5,
                            mandatory = "True",
                            desc = "na "
                        };
                         fileUtility.WriteTestCaseResuItInXML(newcase);
                    }
                }
                else
                {
                    Assert.Contains(_user.FirstName, result.FirstName);
                }
            }
            catch (Exception exception)
            {
                testResult = "BusinessTestFor_SearchUserByEmail_Possitive=" + "False";
                fileUtility.WriteTestCaseResuItInText(testResult);
                // Write test case result in xml file
                if (config["env"] == "development")
                {
                    cases newcase = new cases
                    {
                        TestCaseType = "Business",
                        Name = "BusinessTestFor_SearchUserByEmail_Possitive",
                        expectedOutput = "False",
                        weight = 1,
                        mandatory = "False",
                        desc = "na"
                    };
                     fileUtility.WriteTestCaseResuItInXML(newcase);
                }
            }
        }

        [Fact]
        public async Task BusinessTestFor_SearchUserByMobileNumber_Possitive()
        {
            try
            {
                _adminService = new AdminService(_InMemoryDB.GetUserContext());
                _userService = new UserService(_InMemoryDB.GetUserContext());
                var result1 = await _userService.CreateNewUser(_user);
                var result = await _adminService.SearchUserByMobile(_user.Mobile);
                if (result != null)
                {
                    testResult = "BusinessTestFor_SearchUserByMobileNumber_Possitive=" + "True";
                    fileUtility.WriteTestCaseResuItInText(testResult);
                    // Write test case result in xml file
                    if (config["env"] == "development")
                    {
                        cases newcase = new cases
                        {
                            TestCaseType = "Business",
                            Name = "BusinessTestFor_SearchUserByMobileNumber_Possitive",
                            expectedOutput = "True",
                            weight = 5,
                            mandatory = "True",
                            desc = "na "
                        };
                         fileUtility.WriteTestCaseResuItInXML(newcase);
                    }
                }
                else
                {
                    Assert.Contains(_user.FirstName, result.FirstName);
                }
            }
            catch (Exception exception)
            {
                testResult = "BusinessTestFor_SearchUserByMobileNumber_Possitive=" + "False";
                fileUtility.WriteTestCaseResuItInText(testResult);
                // Write test case result in xml file
                if (config["env"] == "development")
                {
                    cases newcase = new cases
                    {
                        TestCaseType = "Business",
                        Name = "BusinessTestFor_SearchUserByMobileNumber_Possitive",
                        expectedOutput = "False",
                        weight = 1,
                        mandatory = "False",
                        desc = "na"
                    };
                     fileUtility.WriteTestCaseResuItInXML(newcase);
                }
            }
        }
        [Fact]
        public async Task BusinessTestFor_SearchUserBySkillRange_Possitive()
        {
            try
            {
                _adminService = new AdminService(_InMemoryDB.GetUserContext());
                _userService = new UserService(_InMemoryDB.GetUserContext());
                var result1 = await _userService.CreateNewUser(_user);
                var result = await _adminService.SearchUserBySkillRange(2);
                if (result != null)
                {
                    testResult = "BusinessTestFor_SearchUserBySkillRange_Possitive=" + "True";
                    fileUtility.WriteTestCaseResuItInText(testResult);
                    // Write test case result in xml file
                    if (config["env"] == "development")
                    {
                        cases newcase = new cases
                        {
                            TestCaseType = "Business",
                            Name = "BusinessTestFor_SearchUserBySkillRange_Possitive",
                            expectedOutput = "True",
                            weight = 5,
                            mandatory = "True",
                            desc = "na "
                        };
                         fileUtility.WriteTestCaseResuItInXML(newcase);
                    }
                }
                else
                {
                    Assert.Contains(_user.FirstName, result.FirstName);
                }
            }
            catch (Exception exception)
            {
                testResult = "BusinessTestFor_SearchUserBySkillRange_Possitive=" + "False";
                fileUtility.WriteTestCaseResuItInText(testResult);
                // Write test case result in xml file
                if (config["env"] == "development")
                {
                    cases newcase = new cases
                    {
                        TestCaseType = "Business",
                        Name = "BusinessTestFor_SearchUserBySkillRange_Possitive",
                        expectedOutput = "False",
                        weight = 1,
                        mandatory = "False",
                        desc = "na"
                    };
                     fileUtility.WriteTestCaseResuItInXML(newcase);
                }
            }
        }
    }
}
