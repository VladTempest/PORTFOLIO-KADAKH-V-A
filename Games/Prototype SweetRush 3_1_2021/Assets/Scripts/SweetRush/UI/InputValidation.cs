using TMPro;
using UnityEngine;
using UnityEngine.UI;
namespace SweetRush.UI
{
   public class InputValidation : MonoBehaviour
   {
      public TMP_InputField mainInputField=null;
      [SerializeField]
      private int _characterLimit = 7;
      public void Start()
      {
         // Sets the MyValidate method to invoke after the input field's default input validation invoke (default validation happens every time a character is entered into the text field.)
         mainInputField.onValidateInput += delegate(string input, int charIndex, char addedChar) { return MyValidate(addedChar); };
         mainInputField.characterLimit = _characterLimit;
      }
      private char MyValidate(char charToValidate)
      {
         string validcharacters="ABCDEFGHIKLMNOPQRSTVXYZabcdefghiklmnopqrstuxyz1234567890";

         if (validcharacters.IndexOf(charToValidate) != -1)
         {
            return charToValidate;
         }
         return '\0';
         
         
      }
   }
}
