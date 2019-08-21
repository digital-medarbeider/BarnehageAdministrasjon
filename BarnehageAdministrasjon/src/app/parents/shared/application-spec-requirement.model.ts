import { SpecialRequirement } from './special-requirement.model';
import { Application } from './application.model';

export class ApplicationSpecRequirement {
  applicationId: string;
  //application: Application;
  specialRequirementId: number;
  specialRequirement?: SpecialRequirement;
}
