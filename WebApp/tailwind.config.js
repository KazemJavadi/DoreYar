module.exports = {
  mode: 'jit',
  content: ['./Pages/**/*.{cshtml,js}', './Areas/**/*.{cshtml,js}'],
  theme: {
    extend: {},
  },
  variant:{
    extend:{

    }
  },
  plugins: [
    require('@tailwindcss/line-clamp')
  ],
}
