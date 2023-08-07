using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components;

namespace Game.WordGame.Components
{
    public class CustomCssClassProvider<ProviderType> : ComponentBase where ProviderType : FieldCssClassProvider, new()
    {
        [CascadingParameter] public EditContext? CurrentEditContext { get; set; }
        public ProviderType Provider { get; set; } = new ProviderType();
        protected override void OnInitialized()
        {
            if (CurrentEditContext == null)
            {
                throw new InvalidOperationException($"{nameof(DataAnnotationsValidator)} requires a cascading parameter of type {nameof(EditContext)}. For Example, You can use {nameof(DataAnnotationsValidator)} inside an EditForm");
            }
            CurrentEditContext.SetFieldCssClassProvider(Provider);
        }

    }
}
