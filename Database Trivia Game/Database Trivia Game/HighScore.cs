//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Database_Trivia_Game
{
    using System;
    using System.Collections.Generic;
    
    public partial class HighScore
    {
        public int HighScoreID { get; set; }
        public string Name { get; set; }
        public Nullable<int> Score { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
        public string Game { get; set; }
    }
}
