// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 17.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace Microsoft.DotNet.Tools.Scaffold.AspNet.Templates.Identity.Pages.Account.Manage
{
    using System.Collections.Generic;
    using System.Text;
    using System.Linq;
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "17.0.0.0")]
    public partial class SetPasswordModel : SetPasswordModelBase
    {
        /// <summary>
        /// Create the template output
        /// </summary>
        public virtual string TransformText()
        {
            this.Write(@"// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ");
            this.Write(this.ToStringHelper.ToStringWithCulture(Model.UserClassNamespace));
            this.Write(";\r\n\r\nnamespace ");
            this.Write(this.ToStringHelper.ToStringWithCulture(Model.IdentityNamespace));
            this.Write(".Pages.Account.Manage;\r\n\r\npublic class SetPasswordModel : PageModel\r\n{\r\n    priva" +
                    "te readonly UserManager<");
            this.Write(this.ToStringHelper.ToStringWithCulture(Model.UserClassName));
            this.Write("> _userManager;\r\n    private readonly SignInManager<");
            this.Write(this.ToStringHelper.ToStringWithCulture(Model.UserClassName));
            this.Write("> _signInManager;\r\n\r\n    public SetPasswordModel(\r\n        UserManager<");
            this.Write(this.ToStringHelper.ToStringWithCulture(Model.UserClassName));
            this.Write("> userManager,\r\n        SignInManager<");
            this.Write(this.ToStringHelper.ToStringWithCulture(Model.UserClassName));
            this.Write("> signInManager)\r\n    {\r\n        _userManager = userManager;\r\n        _signInMana" +
                    "ger = signInManager;\r\n    }\r\n\r\n    /// <summary>\r\n    ///     This API supports " +
                    "the ASP.NET Core Identity default UI infrastructure and is not intended to be us" +
                    "ed\r\n    ///     directly from your code. This API may change or be removed in fu" +
                    "ture releases.\r\n    /// </summary>\r\n    [BindProperty]\r\n    public InputModel In" +
                    "put { get; set; } = default!;\r\n\r\n    /// <summary>\r\n    ///     This API support" +
                    "s the ASP.NET Core Identity default UI infrastructure and is not intended to be " +
                    "used\r\n    ///     directly from your code. This API may change or be removed in " +
                    "future releases.\r\n    /// </summary>\r\n    [TempData]\r\n    public string? StatusM" +
                    "essage { get; set; }\r\n\r\n    /// <summary>\r\n    ///     This API supports the ASP" +
                    ".NET Core Identity default UI infrastructure and is not intended to be used\r\n   " +
                    " ///     directly from your code. This API may change or be removed in future re" +
                    "leases.\r\n    /// </summary>\r\n    public class InputModel\r\n    {\r\n        /// <su" +
                    "mmary>\r\n        ///     This API supports the ASP.NET Core Identity default UI i" +
                    "nfrastructure and is not intended to be used\r\n        ///     directly from your" +
                    " code. This API may change or be removed in future releases.\r\n        /// </summ" +
                    "ary>\r\n        [Required]\r\n        [StringLength(100, ErrorMessage = \"The {0} mus" +
                    "t be at least {2} and at max {1} characters long.\", MinimumLength = 6)]\r\n       " +
                    " [DataType(DataType.Password)]\r\n        [Display(Name = \"New password\")]\r\n      " +
                    "  public string NewPassword { get; set; } = default!;\r\n\r\n        /// <summary>\r\n" +
                    "        ///     This API supports the ASP.NET Core Identity default UI infrastru" +
                    "cture and is not intended to be used\r\n        ///     directly from your code. T" +
                    "his API may change or be removed in future releases.\r\n        /// </summary>\r\n  " +
                    "      [DataType(DataType.Password)]\r\n        [Display(Name = \"Confirm new passwo" +
                    "rd\")]\r\n        [Compare(\"NewPassword\", ErrorMessage = \"The new password and conf" +
                    "irmation password do not match.\")]\r\n        public string? ConfirmPassword { get" +
                    "; set; }\r\n    }\r\n\r\n    public async Task<IActionResult> OnGetAsync()\r\n    {\r\n   " +
                    "     var user = await _userManager.GetUserAsync(User);\r\n        if (user == null" +
                    ")\r\n        {\r\n            return NotFound($\"Unable to load user with ID \'{_userM" +
                    "anager.GetUserId(User)}\'.\");\r\n        }\r\n\r\n        var hasPassword = await _user" +
                    "Manager.HasPasswordAsync(user);\r\n\r\n        if (hasPassword)\r\n        {\r\n        " +
                    "    return RedirectToPage(\"./ChangePassword\");\r\n        }\r\n\r\n        return Page" +
                    "();\r\n    }\r\n\r\n    public async Task<IActionResult> OnPostAsync()\r\n    {\r\n       " +
                    " if (!ModelState.IsValid)\r\n        {\r\n            return Page();\r\n        }\r\n\r\n " +
                    "       var user = await _userManager.GetUserAsync(User);\r\n        if (user == nu" +
                    "ll)\r\n        {\r\n            return NotFound($\"Unable to load user with ID \'{_use" +
                    "rManager.GetUserId(User)}\'.\");\r\n        }\r\n\r\n        var addPasswordResult = awa" +
                    "it _userManager.AddPasswordAsync(user, Input.NewPassword);\r\n        if (!addPass" +
                    "wordResult.Succeeded)\r\n        {\r\n            foreach (var error in addPasswordR" +
                    "esult.Errors)\r\n            {\r\n                ModelState.AddModelError(string.Em" +
                    "pty, error.Description);\r\n            }\r\n            return Page();\r\n        }\r\n" +
                    "\r\n        await _signInManager.RefreshSignInAsync(user);\r\n        StatusMessage " +
                    "= \"Your password has been set.\";\r\n\r\n        return RedirectToPage();\r\n    }\r\n}\r\n" +
                    "");
            return this.GenerationEnvironment.ToString();
        }
        private global::Microsoft.VisualStudio.TextTemplating.ITextTemplatingEngineHost hostValue;
        /// <summary>
        /// The current host for the text templating engine
        /// </summary>
        public virtual global::Microsoft.VisualStudio.TextTemplating.ITextTemplatingEngineHost Host
        {
            get
            {
                return this.hostValue;
            }
            set
            {
                this.hostValue = value;
            }
        }

private global::Microsoft.DotNet.Tools.Scaffold.AspNet.Models.IdentityModel _ModelField;

/// <summary>
/// Access the Model parameter of the template.
/// </summary>
private global::Microsoft.DotNet.Tools.Scaffold.AspNet.Models.IdentityModel Model
{
    get
    {
        return this._ModelField;
    }
}


/// <summary>
/// Initialize the template
/// </summary>
public virtual void Initialize()
{
    if ((this.Errors.HasErrors == false))
    {
bool ModelValueAcquired = false;
if (this.Session.ContainsKey("Model"))
{
    this._ModelField = ((global::Microsoft.DotNet.Tools.Scaffold.AspNet.Models.IdentityModel)(this.Session["Model"]));
    ModelValueAcquired = true;
}
if ((ModelValueAcquired == false))
{
    string parameterValue = this.Host.ResolveParameterValue("Property", "PropertyDirectiveProcessor", "Model");
    if ((string.IsNullOrEmpty(parameterValue) == false))
    {
        global::System.ComponentModel.TypeConverter tc = global::System.ComponentModel.TypeDescriptor.GetConverter(typeof(global::Microsoft.DotNet.Tools.Scaffold.AspNet.Models.IdentityModel));
        if (((tc != null) 
                    && tc.CanConvertFrom(typeof(string))))
        {
            this._ModelField = ((global::Microsoft.DotNet.Tools.Scaffold.AspNet.Models.IdentityModel)(tc.ConvertFrom(parameterValue)));
            ModelValueAcquired = true;
        }
        else
        {
            this.Error("The type \'Microsoft.DotNet.Tools.Scaffold.AspNet.Models.IdentityModel\' of the par" +
                    "ameter \'Model\' did not match the type of the data passed to the template.");
        }
    }
}
if ((ModelValueAcquired == false))
{
    object data = global::Microsoft.DotNet.Scaffolding.TextTemplating.CallContext.LogicalGetData("Model");
    if ((data != null))
    {
        this._ModelField = ((global::Microsoft.DotNet.Tools.Scaffold.AspNet.Models.IdentityModel)(data));
    }
}


    }
}


    }
    #region Base class
    /// <summary>
    /// Base class for this transformation
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "17.0.0.0")]
    public class SetPasswordModelBase
    {
        #region Fields
        private global::System.Text.StringBuilder generationEnvironmentField;
        private global::System.CodeDom.Compiler.CompilerErrorCollection errorsField;
        private global::System.Collections.Generic.List<int> indentLengthsField;
        private string currentIndentField = "";
        private bool endsWithNewline;
        private global::System.Collections.Generic.IDictionary<string, object> sessionField;
        #endregion
        #region Properties
        /// <summary>
        /// The string builder that generation-time code is using to assemble generated output
        /// </summary>
        public System.Text.StringBuilder GenerationEnvironment
        {
            get
            {
                if ((this.generationEnvironmentField == null))
                {
                    this.generationEnvironmentField = new global::System.Text.StringBuilder();
                }
                return this.generationEnvironmentField;
            }
            set
            {
                this.generationEnvironmentField = value;
            }
        }
        /// <summary>
        /// The error collection for the generation process
        /// </summary>
        public System.CodeDom.Compiler.CompilerErrorCollection Errors
        {
            get
            {
                if ((this.errorsField == null))
                {
                    this.errorsField = new global::System.CodeDom.Compiler.CompilerErrorCollection();
                }
                return this.errorsField;
            }
        }
        /// <summary>
        /// A list of the lengths of each indent that was added with PushIndent
        /// </summary>
        private System.Collections.Generic.List<int> indentLengths
        {
            get
            {
                if ((this.indentLengthsField == null))
                {
                    this.indentLengthsField = new global::System.Collections.Generic.List<int>();
                }
                return this.indentLengthsField;
            }
        }
        /// <summary>
        /// Gets the current indent we use when adding lines to the output
        /// </summary>
        public string CurrentIndent
        {
            get
            {
                return this.currentIndentField;
            }
        }
        /// <summary>
        /// Current transformation session
        /// </summary>
        public virtual global::System.Collections.Generic.IDictionary<string, object> Session
        {
            get
            {
                return this.sessionField;
            }
            set
            {
                this.sessionField = value;
            }
        }
        #endregion
        #region Transform-time helpers
        /// <summary>
        /// Write text directly into the generated output
        /// </summary>
        public void Write(string textToAppend)
        {
            if (string.IsNullOrEmpty(textToAppend))
            {
                return;
            }
            // If we're starting off, or if the previous text ended with a newline,
            // we have to append the current indent first.
            if (((this.GenerationEnvironment.Length == 0) 
                        || this.endsWithNewline))
            {
                this.GenerationEnvironment.Append(this.currentIndentField);
                this.endsWithNewline = false;
            }
            // Check if the current text ends with a newline
            if (textToAppend.EndsWith(global::System.Environment.NewLine, global::System.StringComparison.CurrentCulture))
            {
                this.endsWithNewline = true;
            }
            // This is an optimization. If the current indent is "", then we don't have to do any
            // of the more complex stuff further down.
            if ((this.currentIndentField.Length == 0))
            {
                this.GenerationEnvironment.Append(textToAppend);
                return;
            }
            // Everywhere there is a newline in the text, add an indent after it
            textToAppend = textToAppend.Replace(global::System.Environment.NewLine, (global::System.Environment.NewLine + this.currentIndentField));
            // If the text ends with a newline, then we should strip off the indent added at the very end
            // because the appropriate indent will be added when the next time Write() is called
            if (this.endsWithNewline)
            {
                this.GenerationEnvironment.Append(textToAppend, 0, (textToAppend.Length - this.currentIndentField.Length));
            }
            else
            {
                this.GenerationEnvironment.Append(textToAppend);
            }
        }
        /// <summary>
        /// Write text directly into the generated output
        /// </summary>
        public void WriteLine(string textToAppend)
        {
            this.Write(textToAppend);
            this.GenerationEnvironment.AppendLine();
            this.endsWithNewline = true;
        }
        /// <summary>
        /// Write formatted text directly into the generated output
        /// </summary>
        public void Write(string format, params object[] args)
        {
            this.Write(string.Format(global::System.Globalization.CultureInfo.CurrentCulture, format, args));
        }
        /// <summary>
        /// Write formatted text directly into the generated output
        /// </summary>
        public void WriteLine(string format, params object[] args)
        {
            this.WriteLine(string.Format(global::System.Globalization.CultureInfo.CurrentCulture, format, args));
        }
        /// <summary>
        /// Raise an error
        /// </summary>
        public void Error(string message)
        {
            System.CodeDom.Compiler.CompilerError error = new global::System.CodeDom.Compiler.CompilerError();
            error.ErrorText = message;
            this.Errors.Add(error);
        }
        /// <summary>
        /// Raise a warning
        /// </summary>
        public void Warning(string message)
        {
            System.CodeDom.Compiler.CompilerError error = new global::System.CodeDom.Compiler.CompilerError();
            error.ErrorText = message;
            error.IsWarning = true;
            this.Errors.Add(error);
        }
        /// <summary>
        /// Increase the indent
        /// </summary>
        public void PushIndent(string indent)
        {
            if ((indent == null))
            {
                throw new global::System.ArgumentNullException("indent");
            }
            this.currentIndentField = (this.currentIndentField + indent);
            this.indentLengths.Add(indent.Length);
        }
        /// <summary>
        /// Remove the last indent that was added with PushIndent
        /// </summary>
        public string PopIndent()
        {
            string returnValue = "";
            if ((this.indentLengths.Count > 0))
            {
                int indentLength = this.indentLengths[(this.indentLengths.Count - 1)];
                this.indentLengths.RemoveAt((this.indentLengths.Count - 1));
                if ((indentLength > 0))
                {
                    returnValue = this.currentIndentField.Substring((this.currentIndentField.Length - indentLength));
                    this.currentIndentField = this.currentIndentField.Remove((this.currentIndentField.Length - indentLength));
                }
            }
            return returnValue;
        }
        /// <summary>
        /// Remove any indentation
        /// </summary>
        public void ClearIndent()
        {
            this.indentLengths.Clear();
            this.currentIndentField = "";
        }
        #endregion
        #region ToString Helpers
        /// <summary>
        /// Utility class to produce culture-oriented representation of an object as a string.
        /// </summary>
        public class ToStringInstanceHelper
        {
            private System.IFormatProvider formatProviderField  = global::System.Globalization.CultureInfo.InvariantCulture;
            /// <summary>
            /// Gets or sets format provider to be used by ToStringWithCulture method.
            /// </summary>
            public System.IFormatProvider FormatProvider
            {
                get
                {
                    return this.formatProviderField ;
                }
                set
                {
                    if ((value != null))
                    {
                        this.formatProviderField  = value;
                    }
                }
            }
            /// <summary>
            /// This is called from the compile/run appdomain to convert objects within an expression block to a string
            /// </summary>
            public string ToStringWithCulture(object objectToConvert)
            {
                if ((objectToConvert == null))
                {
                    throw new global::System.ArgumentNullException("objectToConvert");
                }
                System.Type t = objectToConvert.GetType();
                System.Reflection.MethodInfo method = t.GetMethod("ToString", new System.Type[] {
                            typeof(System.IFormatProvider)});
                if ((method == null))
                {
                    return objectToConvert.ToString();
                }
                else
                {
                    return ((string)(method.Invoke(objectToConvert, new object[] {
                                this.formatProviderField })));
                }
            }
        }
        private ToStringInstanceHelper toStringHelperField = new ToStringInstanceHelper();
        /// <summary>
        /// Helper to produce culture-oriented representation of an object as a string
        /// </summary>
        public ToStringInstanceHelper ToStringHelper
        {
            get
            {
                return this.toStringHelperField;
            }
        }
        #endregion
    }
    #endregion
}