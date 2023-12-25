using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public struct AddressMessages
        {
            public static string Added = "Address successfully added.";
            public static string Updated = "Address successfully updated.";
            public static string Removed = "Address successfully removed.";
        }
        public struct CartMessages
        {
            public static string Added = "Cart item successfully added.";
            public static string Updated = "Cart item successfully updated.";
            public static string Removed = "Cart item successfully removed.";
        }
        public struct CategoryMessages
        {
            public static string Added = "Category successfully added.";
            public static string Updated = "Category successfully updated.";
            public static string Removed = "Category successfully removed.";
        }
        public struct CommentMessages
        {
            public static string Added = "Comment successfully added.";
            public static string Updated = "Comment successfully updated.";
            public static string Removed = "Comment successfully removed.";
        }
        public struct CorporateUserAccountMessages
        {
            public static string Added = "Corporate user successfully added.";
            public static string Updated = "Corporate user successfully updated.";
            public static string Removed = "Corporate user successfully removed.";
        }
        public struct FavoriteMessages
        {
            public static string Added = "Favorite successfully added.";
            public static string Removed = "Favorite successfully removed.";
        }
        public struct IndividualUserAccountMessages
        {
            public static string Added = "Individual user successfully added.";
            public static string Updated = "Individual user successfully updated.";
            public static string Removed = "Individual user successfully removed.";
        }
        public struct OrderMessages
        {
            public static string Added = "Order successfully added.";
            public static string Updated = "Order successfully updated.";
            public static string Removed = "Order successfully removed.";
        }
        public struct ProductImageMessages
        {
            public static string Added = "Product image successfully added.";
            public static string Removed = "Product image successfully removed.";
        }
        public struct ProductMessages
        {
            public static string Added = "Product successfully added.";
            public static string Updated = "Product successfully updated.";
            public static string Removed = "Product successfully removed.";
        }
        public struct RegisteredCardMessages
        {
            public static string Added = "Card successfully registered.";
            public static string Updated = "Registered card successfully updated.";
            public static string Removed = "Registered card successfully removed.";
        }
        public struct TicketMessages
        {
            public static string Added = "Ticket successfully created.";
        }
        public struct AuthMessages
        {
            public static string AuthDenied = "User haven't got claim for process";
        }
    }
}
