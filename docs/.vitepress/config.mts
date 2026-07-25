import { defineConfig } from 'vitepress'
import sidebar from './sidebar.mts'
import { tabsMarkdownPlugin } from 'vitepress-plugin-tabs'

// https://vitepress.dev/reference/site-config
export default defineConfig({
  title: "Autossential",
  description: "Autossential Activities Documentation",
  outDir: "../../Output/docs",
  themeConfig: {
    // https://vitepress.dev/reference/default-theme-config
    nav: [
      { text: 'Home', link: '/' },
      { text: 'About', link: '/about' }
    ],

    sidebar,

    socialLinks: [
      { icon: 'github', link: 'https://github.com/alexandretperez' }
    ]
  },
  markdown: {
    config(md) {
      md.use(tabsMarkdownPlugin)
    },
  },
})