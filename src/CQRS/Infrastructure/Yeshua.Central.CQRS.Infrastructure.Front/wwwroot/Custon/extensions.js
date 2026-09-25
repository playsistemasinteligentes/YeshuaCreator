window.yeshuaExtensions = window.yeshuaExtensions || {};
window.yeshuaExtensions.pages = window.yeshuaExtensions.pages || {};
window.yeshuaAppExtensionReady = Promise.resolve();
window.yeshuaLoadApplicationExtension = customAssetsPath => {
    if (!customAssetsPath) return window.yeshuaAppExtensionReady;

    window.yeshuaAppExtensionReady = import(`${customAssetsPath}/extensions.js`)
        .catch(error => console.error('Falha ao carregar extensoes do aplicativo.', error));
    return window.yeshuaAppExtensionReady;
};