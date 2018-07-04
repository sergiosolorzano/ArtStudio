mergeInto(LibraryManager.library, {
    LibraryFullScreen: function () {
        var docElm = document.createElement('canvas');
        if (docElm.requestFullscreen) {
            docElm.requestFullscreen();
            console.log('requestFullscreen requested from api');
        } else if (docElm.mozRequestFullScreen) {
            docElm.mozRequestFullScreen();
            console.log('mozRequestFullScreen requested from api');
        } else if (docElm.webkitRequestFullScreen) {
            docElm.webkitRequestFullScreen();
            console.log('webkitRequestFullScreen requested from api');
        } else if (docElm.msRequestFullscreen) {
            docElm.msRequestFullscreen();
            console.log('msRequestFullscreen requested from api');
        }
    }
});
