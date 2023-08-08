export function getBlazorCulture()
{
    return window.localStorage['BlazorCulture'];
}
export function setBlazorCulture(value)
{
    window.localStorage['BlazorCulture'] = value
}
export function setPageDirection(direction)
{
    document.documentElement.setAttribute("dir", direction);
}
export function updateCSSVariable(name, value)
{
    document.documentElement.style.setProperty(name, value);
}