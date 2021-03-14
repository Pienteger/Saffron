const colors = require('tailwindcss/colors')
module.exports = {
    purge: {
        enabled: true,
        mode: 'all',
        content: [
            '../Pages/**/*.cshtml',
            '../Pages/**/*.html',
            '../Pages/**/*.razor',
            '../Pages/**/*.js']
    },
    darkMode: false, // or 'media' or 'class'
    theme: {
        extend: {
            colors: {
                'light-blue': colors.lightBlue,
                cyan: colors.cyan,
            },
        },
    },
    variants: {},
    plugins: []
}