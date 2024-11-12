import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { ImportDevicesPageComponent } from "./import-devices-page.component";
import { ImportDevicesFormComponent } from "../../business-components/forms/import-devices-form/import-devices-form.component";

const routes: Routes = [
    { path: '', component: ImportDevicesPageComponent},
  ];
  
  @NgModule({
    declarations: [ImportDevicesPageComponent],
    imports: [
      CommonModule,
          RouterModule.forChild(routes),
          ImportDevicesFormComponent
    ]
  })
  export class ImportPageModule { }