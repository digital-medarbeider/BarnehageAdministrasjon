import { ApplicationSpecRequirement } from './application-spec-requirement.model';

export class SpecialRequirement {
  specialRequirementId: number;
  name: string;
  applicationSpecRequirements: ApplicationSpecRequirement[];
}
