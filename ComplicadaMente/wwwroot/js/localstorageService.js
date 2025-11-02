// Backup the original methods
const originalSetItem = window.localStorage.setItem;
const originalGetItem = window.localStorage.getItem;
const originalRemoveItem = window.localStorage.removeItem;
const originalClear = window.localStorage.clear;

// Override the methods with custom ones
Object.defineProperty(window.localStorage, 'setItem', {
    value: function (key, value) {
        console.log('Setting item to localStorage:', key, value);
        originalSetItem.call(window.localStorage, key, value);
    },
    writable: true,
    configurable: true
});

Object.defineProperty(window.localStorage, 'getItem', {
    value: function (key) {
        console.log('Getting item from localStorage:', key);
        return originalGetItem.call(window.localStorage, key);
    },
    writable: true,
    configurable: true
});

Object.defineProperty(window.localStorage, 'removeItem', {
    value: function (key) {
        console.log('Removing item from localStorage:', key);
        originalRemoveItem.call(window.localStorage, key);
    },
    writable: true,
    configurable: true
});

Object.defineProperty(window.localStorage, 'clear', {
    value: function () {
        console.log('Clearing localStorage');
        originalClear.call(window.localStorage);
    },
    writable: true,
    configurable: true
});
