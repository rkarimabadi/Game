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
export function setPageLanguage(language) {
    document.documentElement.setAttribute("lang", language);
}
export function updateCSSVariable(name, value)
{
    document.documentElement.style.setProperty(name, value);
}
export function changeBootstrapTheme(theme) {
    var bootstrapLink = document.querySelector("link[href*='bootstrap']");
    if (bootstrapLink) {
        var path = bootstrapLink.getAttribute("href");
        if (path.endsWith(".min.css")) {
            bootstrapLink.setAttribute("href", path.slice(0, -7) + theme + ".min.css");
        }
    }
}