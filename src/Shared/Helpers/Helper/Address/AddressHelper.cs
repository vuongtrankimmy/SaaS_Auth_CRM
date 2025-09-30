using Entities.Inherits.Address;
using Helpers.Helper.Convert;
using PCRE;
using System.Text.RegularExpressions;

namespace Shared.Helpers.Helper.Address
{
    public static class AddressHelper
    {
        #region ADDRESS PARSER

        /// <summary>
        /// Address Parser
        /// </summary>
        /// <param name="fullAddress"></param>
        /// <returns></returns>
        public static AddressDTOs ToAddressParser(this string fullAddress)
        {
            AddressDTOs? address = null;
            if (!string.IsNullOrEmpty(fullAddress))
            {
                var pattern = @"\A\s*
                                (?: #########################################################################
                                    # Option A: [<Addition to address 1>] <House number> <Street name>      #
                                    # [<Addition to address 2>]                                             #
                                    #########################################################################
                                    (?:(?P<A_address_1>.*?)
                                ,\s*)? # Addition to address 1
                                (?:No\.\s*)?
                                    (?P<A_House_number_1>\pN+[a-zA-Z]?(?:\s*[-\/\pP]\s*\pN+[a-zA-Z]?)*) # House number
                                \s*,?\s*
                                    (?P<A_Street_1>(?:[a-zA-Z]\s*|\pN\pL{2,}\s\pL)\S[^,#]*?(?<!\s)) # Street name
                                \s*(?:(?:[,\/]|(?=\#))\s(?!\sNo\.)
                                \s*,?\s*
                                    (?P<A_Ward_1>(?:[a-zA-Z]\s*|\pN\pL{2,}\s\pL)\S[^,#]*?(?<!\s)) # Ward name
                                \s*(?:(?:[,\/]|(?=\#))\s(?!\sP\.))
                                \s*,?\s*
                                    (?P<A_District_1>(?:[a-zA-Z]\s*|\pN\pL{2,}\s\pL)\S[^,#]*?(?<!\s)) # District name
                                \s*(?:(?:[,\/]|(?=\#))\s(?!\sQ\.))
                                \s*,?\s*
                                    (?P<A_City_1>(?:[a-zA-Z]\s*|\pN\pL{2,}\s\pL)\S[^,#]*?(?<!\s)) # City name
                                \s*(?:(?:[,\/]|(?=\#))\s(?!\sTP\.))
                                    (?P<A_Country_1>(?!\s).*?))? # Addition to address 2
                                |

                                    (?:(?P<B_address_1>.*?)
                                ,\s*)? # Addition to address 1
                                (?:No\.\s*)?
                                    (?P<B_House_number_1>\pN+[a-zA-Z]?(?:\s*[-\/\pP]\s*\pN+[a-zA-Z]?)*) # House number
                                \s*,?\s*
                                    (?P<B_Street_1>(?:[a-zA-Z]\s*|\pN\pL{2,}\s\pL)\S[^,#]*?(?<!\s)) # Street name
                                \s*(?:(?:[,\/]|(?=\#))\s(?!\sNo\.)
                                \s*,?\s*
                                    (?P<B_Ward_1>(?:[a-zA-Z]\s*|\pN\pL{2,}\s\pL)\S[^,#]*?(?<!\s)) # Street name
                                \s*(?:(?:[,\/]|(?=\#))\s(?!\sP\.))
                                \s*,?\s*
                                    (?P<B_District_1>(?:[a-zA-Z]\s*|\pN\pL{2,}\s\pL)\S[^,#]*?(?<!\s)) # Street name
                                \s*(?:(?:[,\/]|(?=\#))\s(?!\sQ\.))
                                    (?P<B_City_1>(?!\s).*?))? # Addition to address 2
                                |

                                  (?:(?P<C_address_1>.*?)
                                ,\s*)? # Addition to address 1
                                (?:No\.\s*)?
                                    (?P<C_House_number_1>\pN+[a-zA-Z]?(?:\s*[-\/\pP]\s*\pN+[a-zA-Z]?)*) # House number
                                \s*,?\s*
                                    (?P<C_Street_1>(?:[a-zA-Z]\s*|\pN\pL{2,}\s\pL)\S[^,#]*?(?<!\s)) # Street name
                                \s*(?:(?:[,\/]|(?=\#))\s(?!\sNo\.)
                                \s*,?\s*
                                    (?P<C_Ward_1>(?:[a-zA-Z]\s*|\pN\pL{2,}\s\pL)\S[^,#]*?(?<!\s)) # Street name
                                \s*(?:(?:[,\/]|(?=\#))\s(?!\sP\.))
                                    (?P<C_City_1>(?!\s).*?))? # Addition to address 2
                                |
                                  (?:(?P<D_address_1>.*?)
                                ,\s*)? # Addition to address 1
                                (?:No\.\s*)?
                                    (?P<D_House_number_1>\pN+[a-zA-Z]?(?:\s*[-\/\pP]\s*\pN+[a-zA-Z]?)*) # House number
                                \s*,?\s*
                                    (?P<D_Street_1>(?:[a-zA-Z]\s*|\pN\pL{2,}\s\pL)\S[^,#]*?(?<!\s)) # Street name
                                \s*(?:(?:[,\/]|(?=\#))\s(?!\sNo\.)
                                    (?P<D_City_1>(?!\s).*?))? # Addition to address 2
                                |
                                   #########################################################################
                                    # Option B: [<Addition to address 1>] <Street name> <House number>      #
                                    # [<Addition to address 2>]                                             #
                                    #########################################################################
                                    (?:(?P<B_Addition_to_address_1>.*?),\s*(?=.*[,\/]))? # Addition to address 1
                                    (?!\s*No\.)(?P<B_Street_name>\S\s*\S(?:[^,#](?!\b\pN+\s))*?(?<!\s)) # Street name
                                \s*[\/,]?\s*(?:\sNo\.)?\s+
                                    (?P<B_House_number>\pN+\s*-?[a-zA-Z]?(?:\s*[-\/\pP]?\s*\pN+(?:\s*[\-a-zA-Z])?)*|[IVXLCDM]+(?!.*\b\pN+\b))(?<!\s) # House number
                                \s*(?:(?:[,\/]|(?=\#)|\s)\s*(?!\s*No\.)\s*
                                    (?P<B_Addition_to_address_2>(?!\s).*?))? # Addition to address 2
                                )
                                \s*\Z";

                fullAddress = fullAddress.ToCapitalize().Replace("Số ", "").Replace("Đường ", "").Replace("Ngõ ", "").Replace("Đ. ", "").Replace("Đ.", "");

                var regex = new PcreRegex(pattern, PcreOptions.Extended);
                var groupList = regex.Match(fullAddress);
                var groupMatchList = groupList.Where(x => !string.IsNullOrEmpty(x)).Select(x => x.ToString()).ToList();
                var fullAddressSplit = fullAddress.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries)?.ToList();
                var objectTotal = fullAddressSplit?.Count - (groupMatchList?.Count);
                if (groupMatchList == null || !groupMatchList.Any() || (objectTotal >= 3 && groupMatchList?.Count > 4))
                {
                    groupMatchList = new List<string>();
                    groupMatchList?.Add(fullAddress);
                    if (fullAddressSplit != null && fullAddressSplit.Any() && fullAddressSplit.Count > 3)
                    {
                        groupMatchList?.AddRange(fullAddressSplit);
                    }
                }
                if (fullAddressSplit != null && fullAddressSplit.Any() && fullAddressSplit.Count > 1)
                {
                    address = new AddressDTOs();
                    address.fullAddress = fullAddress;
                    var groupMath = fullAddressSplit?.ToList();
                    //var groupMath = groupMatchList?.Skip(1).ToList();

                    groupMath?.Reverse();
                    var address1List = new List<string>();
                    groupMath?.ForEach(x =>
                    {
                        if (!string.IsNullOrEmpty(x))
                        {
                            var outY = x;

                            if ((!string.IsNullOrEmpty(address.cityName))
                            && !string.IsNullOrEmpty(address.wardName)
                            && !string.IsNullOrEmpty(address.districtName))
                            {
                                address1List.Add(x?.Trim());
                            }

                            if (string.IsNullOrEmpty(address.cityName) && (x.GetCity(out outY) || groupMath.Count > 3))
                            {
                                address.cityName = outY?.Trim();
                            }
                            else if (string.IsNullOrEmpty(address.districtName) && (x.GetDistrict(out outY) || groupMath.Count > 3))
                            {
                                address.districtName = outY?.Trim();
                            }
                            else if (string.IsNullOrEmpty(address.wardName) && (x.GetWard(out outY) || groupMath.Count > 3))
                            {
                                address.wardName = outY?.Trim();
                            }
                            //else if (x.GetZip())
                            //{
                            //    address.zipcode = x;
                            //}
                            //else if (x.GetSuffix())
                            //{
                            //    address.suffix = x;
                            //}
                            //if (x.GetHouseNumber() && !string.IsNullOrEmpty(address.streetName) && string.IsNullOrEmpty(address.houseNumber))
                            //{
                            //    address.houseNumber = x;
                            //}
                            //else if (string.IsNullOrEmpty(address.houseNumber) && string.IsNullOrEmpty(address.streetName))
                            //{
                            //    address.streetName = x;
                            //}
                        }
                    });
                    if (address1List != null && address1List.Any())
                        address1List.Reverse();
                    {
                        string address1 = string.Join(", ", address1List);
                        address.suffix = address1;
                    }
                }
            }
            return address;
        }

        public static bool GetLocation(this string location)
        {
            var pattern = @"^(?:(?P<address>.*?),\s*)?";
            return PCRE.PcreRegex.IsMatch(location, pattern);
        }

        public static bool GetStreet(this string street)
        {
            var pattern = @"^(?P<street>(?:[a-zA-Z]\s*|\pN\pL{2,}\s\pL)\S[^,#]*?(?<!\s))";
            return PCRE.PcreRegex.IsMatch(street, pattern);
        }

        public static bool GetHouseNumber(this string houseNumber)
        {
            var pattern = @"^(?:No\.\s*)?(?P<A_House_number_1>\pN+[a-zA-Z]?(?:\s*[-\/\pP]\s*\pN+[a-zA-Z]?)*)";
            return PCRE.PcreRegex.IsMatch(houseNumber, pattern);
        }

        public static bool GetZip(this string zip)
        {
            var pattern = @"^(?<zip>\d{5})";
            return Regex.IsMatch(zip, pattern);
        }

        public static bool GetWard(this string ward, out string x)
        {
            ward = ward.Trim().ToLower();
            var restr = ward;
            var patternList = new List<string> {
            "ward ",
            "wrd ",
            "wrd",
            "phuong ",
            "phường ",
            "p ",
            "p. ",
            "thôn ",
            "huyện ",
            "h. ",
            "thị trấn ",
            "tt",
            "xã ",
            "x. "
            };
            var result = patternList.FirstOrDefault(ward.Contains) != null;
            x = restr;
            if (result)
            {
                foreach (var pattern in patternList)
                {
                    x = x.Replace(pattern, "");
                };
            }
            return result;
        }

        public static bool GetDistrict(this string district, out string x)
        {
            district = district.Trim().ToLower();
            var restr = district;
            var patternList = new List<string> {
            "district ",
            "dr ",
            "dist. ",
            "quan ",
            "quận ",
            "thanh pho ",
            "thành phố ",
            "q ",
            "q. ",
            "huyện ",
            "h. ",
            "thị xã ",
            "tx. ",
            };

            var result = patternList.FirstOrDefault(district.Contains) != null;
            x = restr;
            if (result)
            {
                foreach (var pattern in patternList)
                {
                    x = x.Replace(pattern, "").Trim();
                };
            }
            return result;
        }

        public static bool GetCity(this string city, out string x)
        {
            city = city.Trim().ToLower();
            var restr = city;
            var patternList = new List<string> {
            "city",
            "tp ",
            "tp.",
            "tỉnh.",
            "tỉnh ",
            "thanh pho ",
            "thành phố ",
            "thu do ",
            "thủ đô ",
            };
            var result = patternList.FirstOrDefault(city.Contains) != null;
            x = restr;
            if (result)
            {
                foreach (var pattern in patternList)
                {
                    x = x.Replace(pattern, "").Trim();
                };
            }
            return result;
        }

        public static bool GetSuffix(this string suffix)
        {
            var pattern = @"^(?: *\\((?<suffix>[^\\)]+)\\))?";
            return Regex.IsMatch(suffix, pattern);
        }

        #endregion ADDRESS PARSER
    }
}