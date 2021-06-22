mergeInto(LibraryManager.library, {

    Save: function (str) {
        window.localStorage.setItem('scholar-dungeon-game', Pointer_stringify(str));
    },

    Load: function () {
        var str = window.localStorage.getItem('scholar-dungeon-game');
        var bufferSize = lengthBytesUTF8(str) + 1;
        var buffer = _malloc(bufferSize);
        stringToUTF8(str, buffer, bufferSize);
        return buffer;
    },

});