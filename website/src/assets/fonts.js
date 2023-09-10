import localFont from "next/font/local";

export const neue = localFont({ 
    src: [
      {
        path: './neue/NeueHaasDisplayBlack.ttf',
        weight: '400',
        style: 'normal'
      },
      {
        path: './neue/NeueHaasDisplayBold.ttf',
        weight: '700',
        style: 'normal'
      },
      {
        path: './neue/NeueHaasDisplayLight.ttf',
        weight: '100',
        style: 'normal'
      }
    ]
});