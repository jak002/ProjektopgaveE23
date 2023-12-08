namespace ProjektopgaveE23.Helpers
{
    public static class InputValidator
    {
        public static bool ValidateEmail(string email)
        {
            if (email != null && !email.Contains("@") && !email.Contains("."))
            {
                return false;
            }
            return true;
        }

        public static bool ValidatePhone(string phone)
        {
            for (int i = 0; i < phone.Length; i++)
            {
                if (phone[i] == ' ' || phone[i] == '+' || phone[i] == '0' || phone[i] == '1' || phone[i] == '2' || phone[i] == '3' || phone[i] == '4' || phone[i] == '5' || phone[i] == '6' || phone[i] == '7' || phone[i] == '8' || phone[i] == '9')
                {
                    continue;
                } else
                {
                    return false;
                }
            }
            return true;
        }
    }
}
