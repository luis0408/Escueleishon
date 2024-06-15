import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';

import { AppModule } from './app/app.module';



export function getBaseUrl() {
  //return document.getElementsByTagName('base')[0].href;
  return "https://localhost:7132";
}

const providers = [
  { provide: 'BASE_URL', useFactory: getBaseUrl, deps: [] }
];


platformBrowserDynamic().bootstrapModule(AppModule)
  .catch(err => console.error(err));